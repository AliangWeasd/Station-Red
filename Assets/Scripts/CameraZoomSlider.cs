using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraZoomSlider : MonoBehaviour
{
    public string SearchTag = "MainCamera";

    private Camera camComponent;
    private Slider zoomSlider;

    void Start()
    {
        camComponent = GameObject.FindWithTag(SearchTag).GetComponent<Camera>();
        zoomSlider = GetComponent<Slider>();

        if (camComponent == null)
        {
            throw new Exception("A camera required to use this script. What are you doing?");
        }
        if(zoomSlider == null)
        {
            throw new Exception("A Slider required to use this script");
        }

        zoomSlider.onValueChanged.AddListener(delegate { ZoomChange(zoomSlider); });
    }

    void ZoomChange(Slider zoomSlider)
    {
        camComponent.orthographicSize = zoomSlider.value;
    }
}
