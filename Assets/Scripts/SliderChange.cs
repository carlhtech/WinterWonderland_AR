using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderChange : MonoBehaviour
{
    private PaintVertices paintVertices;

    public Slider mainSlider;

    private float jsValue;


    void Awake(){
        paintVertices = GetComponent<PaintVertices>();

    }


    // Use this for initialization
    void Start()
    {
        jsValue = paintVertices.radius;

        mainSlider.onValueChanged.AddListener(delegate {
            ValueChangeCheck();
        });
    }


    public void ValueChangeCheck()
    {
        mainSlider.value = jsValue;
    }

}