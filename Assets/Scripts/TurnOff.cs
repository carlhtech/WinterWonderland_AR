using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;


public class TurnOff : MonoBehaviour {

    public GameObject script;
    public GameObject planes;
    public GameObject doneButton;


    public void Button(){
        script.SetActive(false);
        planes.SetActive(false);
        doneButton.SetActive(false);
    }
}
