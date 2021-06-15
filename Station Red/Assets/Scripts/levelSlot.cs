using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSlot : MonoBehaviour
{
    static int levelSelected = -1;
    public int levelIndex = 0;
    public int record = 0;

    private const string HIGHSCORE_KEY = "highscore";

    void Start()
    {
        SR_MenuEvents.current.onLeftPressed += LeftPressed;
        SR_MenuEvents.current.onRightPressed += RightPressed;

        GetComponent<Image>().sprite = GetComponentInParent<LevelSlotData>().getPicture(levelIndex);
        GetComponent<Button>().onClick.AddListener(() => GoToLevel(levelIndex));
        record = PlayerPrefs.GetInt(HIGHSCORE_KEY + levelIndex);

        UIEvents.current.StopTimeCount();
    }

    void OnDestroy()
    {
        SR_MenuEvents.current.onLeftPressed -= LeftPressed;
        SR_MenuEvents.current.onRightPressed -= RightPressed;
    }

    public void LeftPressed()
    {
        levelIndex -= 10;
        record = PlayerPrefs.GetInt(HIGHSCORE_KEY + levelIndex);
        GetComponent<Image>().sprite = GetComponentInParent<LevelSlotData>().getPicture(levelIndex);
    }

    public void RightPressed()
    {
        levelIndex += 10;
        record = PlayerPrefs.GetInt(HIGHSCORE_KEY + levelIndex);
        GetComponent<Image>().sprite = GetComponentInParent<LevelSlotData>().getPicture(levelIndex);
    }

    public void GoToLevel(int levelIndex)
    {
        if (levelSelected == levelIndex)
        {
            levelSelected = -1;

            // Temporary
            if (this.levelIndex >= 10)
            {
                SceneManager.LoadScene("Level_02", LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene("Level_01", LoadSceneMode.Single);
            }
        }
        else
        {
            levelSelected = levelIndex;
            UIEvents.current.StartRecordCount(record);
            UIEvents.current.RecordTime();
        }
    }

    public void setRecord(int record)
    {
        this.record = record;
    }

    public int getRecord()
    {
        return record;
    }
}
