using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SR_MenuEvents : MonoBehaviour
{
    public static SR_MenuEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onPlayPressed;
    public event Action onLevelsPressed;
    public event Action onHelpPressed;
    public event Action onOptionsPressed;
    public event Action onOptionsBackPressed;
    public event Action onBackPressed;
    public event Action onQuitPressed;
    public event Action onMutePressed;
    public event Action onStartPressed;
    public event Action onLeftPressed;
    public event Action onRightPressed;
    public event Action onIndexLeast;
    public event Action onIndexMost;
    public event Action onIndexBetween;

    public void PlayPressed()
    {
        if (onPlayPressed != null)
        {
            onPlayPressed();
        }
    }

    public void LevelsPressed()
    {
        if (onLevelsPressed != null)
        {
            onLevelsPressed();
        }
    }

    public void HelpPressed()
    {
        if (onHelpPressed != null)
        {
            onHelpPressed();
        }
    }

    public void OptionsPressed()
    {
        if (onOptionsPressed != null)
        {
            onOptionsPressed();
        }
    }

    public void OptionsBackPressed()
    {
        if (onOptionsBackPressed != null)
        {
            onOptionsBackPressed();
        }
    }

    public void BackPressed()
    {
        if (onBackPressed != null)
        {
            onBackPressed();
        }
    }

    public void QuitPressed()
    {
        if (onQuitPressed != null)
        {
            onQuitPressed();
        }
    }

    public void MutePressed()
    {
        if (onMutePressed != null)
        {
            onMutePressed();
        }
    }

    public void StartPressed()
    {
        if (onStartPressed != null)
        {
            onStartPressed();
        }
    }

    public void LeftPressed()
    {
        if (onLeftPressed != null)
        {
            onLeftPressed();
        }
    }

    public void RightPressed()
    {
        if (onRightPressed != null)
        {
            onRightPressed();
        }
    }

    public void IndexLeast()
    {
        if (onIndexLeast != null)
        {
            onIndexLeast();
        }
    }

    public void IndexMost()
    {
        if (onIndexMost != null)
        {
            onIndexMost();
        }
    }

    public void IndexBetween()
    {
        if (onIndexBetween != null)
        {
            onIndexBetween();
        }
    }
}
