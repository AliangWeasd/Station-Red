using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private GameObject mainMusic;
    private GameObject levelMusic;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.activeSceneChanged += ChangedActiveScene;
        
        mainMusic = this.gameObject.transform.GetChild(0).gameObject;
        levelMusic = this.gameObject.transform.GetChild(1).gameObject;
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (next.name == "TitleScene")
        {
            mainMusic.GetComponent<AudioSource>().enabled = true;
            levelMusic.GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            mainMusic.GetComponent<AudioSource>().enabled = false;
            levelMusic.GetComponent<AudioSource>().enabled = true;
        }
    }
}
