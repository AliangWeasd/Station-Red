using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        if(btn = GetComponent<Button>()){
            btn.onClick.AddListener(ResetScene);
        }
        else
        {
            throw new Exception("Button component required to use this script.");
        }
    }

    void ResetScene()
    {
        if (ButtonManager.current != null)
        {
            Scene scene = SceneManager.GetActiveScene();
            ButtonManager.current.ButtonMoveSceneSingle(scene.name);
        }
    }
}
