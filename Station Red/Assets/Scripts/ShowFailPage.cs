using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFailPage : MonoBehaviour
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

    private Camera cam;

    private const string HIGHSCORE_KEY = "highscore";
    public string LEVEL = "1";

    private int recordTime = 0;

    void Start()
    {
        GameEvents.current.onPlayerDeath += FailStateReached;

        record = this.gameObject.transform.GetChild(0).gameObject;

        cam = Camera.main;

        setAppear(false);
    }

    void OnDestroy()
    {
        GameEvents.current.onPlayerDeath -= FailStateReached;
    }

    public void FailStateReached()
    {
        endPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, cam.nearClipPlane));
        startPos = transform.position;

        recordTime = PlayerPrefs.GetInt(HIGHSCORE_KEY + LEVEL);

        StartCoroutine(Fall());
    }

    IEnumerator Fall()
    {
        setAppear(true);

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

        UIEvents.current.StartFailCount(recordTime);

        UIEvents.current.FailTime();
        while (!Input.GetButtonDown("Submit"))
        {
            yield return new WaitForEndOfFrame();
        }
        UIEvents.current.StopTimeCount();
    }

    void setAppear(bool isOn)
    {
        GetComponent<Image>().enabled = isOn;

        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(isOn);
        }
    }
}
