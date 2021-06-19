using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public AudioClip menuMusic;

    void Awake()
    {
        if (AudioManager.current == null)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.current.PlayMusic(menuMusic);
    }
}
