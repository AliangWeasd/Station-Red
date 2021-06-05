using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPage : MonoBehaviour
{
    public float delta_y = 0f;
    public float y_end = 0f;
    public int frames = 0;

    public AnimationCurve showCurve;
    public AnimationCurve leaveCurve;
    public Vector3 startPos = new Vector3();
    public Vector3 endPos = new Vector3();
    public float timeInSec = 1f;

    private GameObject record;
    private GameObject current;
    private GameObject hearts;

    private Camera cam;

    private const string HIGHSCORE_KEY = "highscore";
    public string LEVEL = "0";

    void Start()
    {
        GameEvents.current.onWinStateReached += WinStateReached;

        record = this.gameObject.transform.GetChild(0).gameObject;
        current = this.gameObject.transform.GetChild(1).gameObject;
        hearts = this.gameObject.transform.GetChild(2).gameObject;

        cam = Camera.main;
    }

    public void WinStateReached()
    {
        int heartLeft = GameObject.Find("HealthBar").GetComponent<HealthBar>().currentAmount;
        ClockTimer timer = GameObject.Find("Timer").GetComponent<ClockTimer>();
        current.GetComponent<ClockTimer>().SetTime(timer.GetDecimal(), timer.GetSecond(), timer.GetMinute());
        StartCoroutine(Launch(3 - heartLeft));
    }

    IEnumerator Launch(int heartsLost)
    {
        endPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, cam.nearClipPlane));
        startPos = transform.position;

        Vector3 distance = endPos - startPos;

        float timer = 0.0f;
        while (timer <= timeInSec && !Input.GetButtonDown("Submit"))
        {
            Vector3 pos = startPos + (distance * showCurve.Evaluate(timer / timeInSec));
            transform.position = new Vector3(pos.x, pos.y, 2);

            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = new Vector3(endPos.x, endPos.y, 2);

        int recordTime = PlayerPrefs.GetInt(HIGHSCORE_KEY + LEVEL);
        int yourTime = int.Parse(GameObject.Find("Timer").GetComponent<Text>().text);

        // Calculating time
        int decimalDigits = (int)(yourTime % 1000);
        int secondDigits = (int)(yourTime / 1000);
        int minuteDigits = (int)(secondDigits / 60);
        // Calculating time
        secondDigits += (10 * heartsLost);
        minuteDigits += (int)(secondDigits / 60);
        secondDigits = secondDigits % 60;
        // Final Time
        int time = minuteDigits * 100000 + secondDigits * 1000 + decimalDigits;

        // Saving the time
        /*
        if (recordTime > yourTime)
        {
            PlayerPrefs.SetInt(HIGHSCORE_KEY + LEVEL, yourTime);
        }*/
        PlayerPrefs.SetInt(HIGHSCORE_KEY + LEVEL, time);

        // Aesthetics
        // Currently, once the counting animation starts, there is no way to cut it short.
        // Would need to be reworked to change this.
        // Anticipated issues:
        //  AddTime would overcount if stopped while counting.
        if (Input.GetButtonDown("Submit"))
        {
            GameEvents.current.StopTimeCount();
            record.SendMessage("CountInstant", recordTime);
            current.SendMessage("CountInstant", yourTime);
            hearts.SendMessage("TimeCalcInstant", heartsLost);
            current.SendMessage("AddTime", 10 * heartsLost);
        }
        else
        {
            //List times
            record.SendMessage("Count", recordTime);
            GameEvents.current.TimeCount();
            yield return new WaitForSeconds(1);
            current.SendMessage("Count", yourTime);
            GameEvents.current.TimeCount();
            yield return new WaitForSeconds(1.5f);

            for (int x = 0; x < heartsLost; x++)
            {
                hearts.SendMessage("LoseHeart");
                current.SendMessage("AddTime", 10);
                GameEvents.current.CountHeartLost();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
