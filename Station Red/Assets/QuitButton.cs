using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    public string MainMenuName = "TitleScene";

    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        if (btn = GetComponent<Button>())
        {
            btn.onClick.AddListener(QuitScene);
        }
        else
        {
            throw new Exception("Button component required to use this script.");
        }
    }

    void QuitScene()
    {
        if (ButtonManager.current != null)
        {
            Scene scene = SceneManager.GetActiveScene();

            if (scene.name != MainMenuName)
                ButtonManager.current.ButtonMoveSceneSingle(MainMenuName);
            else
                ButtonManager.current.QuitPressed();
        }
        else
        {
            throw new Exception("No ButtonManager to command.");
        }
    }
}
