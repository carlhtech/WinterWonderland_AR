using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {


    private Transform transformItem;

    RaycastHit hit;
    Ray ray;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit)){
            transformItem = hit.collider.transform;
        }

        if(Input.touchCount > 1){
            
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved){
                transformItem.transform.Rotate(0f, touch.deltaPosition.x, 0f);
            }
        }
	}
}
