using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void ButtonMoveSceneAdditive(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Additive);
    }

    public void ButtonMoveSceneSingle(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    public void ButtonUnloadSceneAsync(string level)
    {
        SceneManager.UnloadSceneAsync(level);
    }

    public void PlayPressed()
    {
        SR_MenuEvents.current.PlayPressed();
    }

    public void HelpPressed()
    {
        SR_MenuEvents.current.HelpPressed();
    }

    public void OptionsPressed()
    {
        SR_MenuEvents.current.OptionsPressed();
    }

    public void OptionsBackPressed()
    {
        SR_MenuEvents.current.OptionsBackPressed();
        PlayerPrefs.Save();
    }

    public void BackPressed()
    {
        SR_MenuEvents.current.BackPressed();
    }

    public void QuitPressed()
    {
        SR_MenuEvents.current.QuitPressed();
        Application.Quit();
    }

    public void MutePressed()
    {
        SR_MenuEvents.current.MutePressed();
    }

    public void StartPressed()
    {
        SR_MenuEvents.current.StartPressed();
    }

    public void LeftPressed()
    {
        SR_MenuEvents.current.LeftPressed();
    }

    public void RightPressed()
    {
        SR_MenuEvents.current.RightPressed();
    }
}
