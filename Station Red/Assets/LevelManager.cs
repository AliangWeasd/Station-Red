using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private const string LAST_LEVEL = "lastlevel";

    public GameObject MainPanel;
    public GameObject LevelPanel;

    public int pageIndex = 0;
    public int PAGE_MAX = 2;

    //private bool isLeast = false;
    //private bool isMost = false;
    //private bool isBetween = false;

    void Awake()
    {
        SR_MenuEvents.current.onLeftPressed += LeftPressed;
        SR_MenuEvents.current.onRightPressed += RightPressed;
    }

    // Start is called before the first frame update
    void Start()
    {
        int lastlevel = PlayerPrefs.GetInt(LAST_LEVEL);

        if (lastlevel != -1)
        {
            MainPanel.GetComponent<ShowMenuCard>().LaunchInstant();
            LevelPanel.GetComponent<ShowMenuCard>().LaunchInstant();
        }
        else
        {
            lastlevel = 0;
            PlayerPrefs.SetInt(LAST_LEVEL, lastlevel);
        }

        SR_MenuEvents.current.IndexBetween();

        int savedPage = lastlevel / 10;
        if(savedPage == 0)
        {
            SR_MenuEvents.current.IndexLeast();
        }
        else if(savedPage == PAGE_MAX - 1)
        {
            SR_MenuEvents.current.IndexMost();
        }
    }

    public void SetLastLevel(int level)
    {
        PlayerPrefs.SetInt(LAST_LEVEL, level);
    }

    public void LeftPressed()
    {
        SR_MenuEvents.current.IndexBetween();
        pageIndex--;

        if (pageIndex <= 0)
        {
            SR_MenuEvents.current.IndexLeast();
            pageIndex = 0;
        }
    }

    public void RightPressed()
    {
        SR_MenuEvents.current.IndexBetween();
        pageIndex++;

        if (pageIndex >= PAGE_MAX - 1)
        {
            SR_MenuEvents.current.IndexMost();
            pageIndex = PAGE_MAX - 1;
        }
    }

    public int getIndex()
    {
        return pageIndex;
    }

    public int getMax()
    {
        return PAGE_MAX;
    }
}