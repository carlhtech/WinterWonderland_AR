using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectEditor : MonoBehaviour {

    public GameObject canvasEditor;

    private GameObject selectedObject;
    private Transform transformObject;

    private float transformSpeed = 0.001f;

    private bool leftRightOn;
    private bool upDownOn;
    private bool rotateOn;
    private bool scaleOn;
    private bool deleteOn;

    public Button leftRightButton;
    public Button upDownButton;
    public Button rotateButton;
    public Button scaleButton;
    public Button deleteButton;


    Ray ray;
    RaycastHit hit;


	private void Awake()
	{
        leftRightButton = leftRightButton.GetComponent<Button>();
        upDownButton = upDownButton.GetComponent<Button>();
        rotateButton = rotateButton.GetComponent<Button>();
        scaleButton = scaleButton.GetComponent<Button>();
        deleteButton = deleteButton.GetComponent<Button>();


	}



    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
	
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       

        if(Physics.Raycast(ray, out hit)){
            selectedObject = hit.collider.gameObject;
            transformObject = selectedObject.transform;

            if ((leftRightOn) && !IsPointerOverUIObject()){
                if (Input.touchCount > 0)
                {
                    var touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Moved)
                    {
                        transformObject.transform.Translate(touch.deltaPosition.x * transformSpeed, 0f, touch.deltaPosition.y * transformSpeed, Space.World);
                    }
                }
            }

            else if ((rotateOn) && !IsPointerOverUIObject()){
                if(Input.touchCount > 0){
                    var touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Moved){
                        transformObject.transform.Rotate(0f, touch.deltaPosition.x, 0f);
                    }
                }
            }

            else if ((upDownOn) && !IsPointerOverUIObject()){
                if(Input.touchCount > 0){
                    var touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Moved){
                        
                        transformObject.transform.Translate(0f, touch.deltaPosition.y * transformSpeed, 0f);
                    }
                }
            }

            /*else if ((scaleOn) && !IsPointerOverUIObject())
            {
                if (Input.touchCount > 0)
                {
                    var touch = Input.GetTouch(0);
                    if (touch.phase == TouchPhase.Moved)
                    {
                        transformObject.transform.localScale (0f, touch.deltaPosition.y * transformSpeed, 0f);
                    }
                }
            }*/

            else if ((deleteOn) && !IsPointerOverUIObject())
            {
                Destroy(selectedObject);
            }

            else if ((scaleOn) && !IsPointerOverUIObject()){
                if (Input.touchCount == 2)
                {
                    // Store both touches.
                    Touch touchZero = Input.GetTouch(0);
                    Touch touchOne = Input.GetTouch(1);

                    // Find the position in the previous frame of each touch.
                    Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                    Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                    // Find the magnitude of the vector (the distance) between the touches in each frame.
                    float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                    float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                    // Find the difference in the distances between each frame.
                    float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                    Vector3 newScale = selectedObject.transform.localScale - new Vector3(deltaMagnitudeDiff, deltaMagnitudeDiff, deltaMagnitudeDiff);
                    selectedObject.transform.localScale = newScale;
                }
            }
        }
	}

    public void leftRightPress()
    {
       
        if(leftRightOn == false)
        {
            leftRightOn = true;
            upDownOn = false;
            rotateOn = false;
            scaleOn = false;
            deleteOn = false;
            if (leftRightOn)
            {
                leftRightButton.GetComponent<Image>().color = new Color32(113, 167, 198, 255);
                upDownButton.GetComponent<Image>().color = Color.white;
                rotateButton.GetComponent<Image>().color = Color.white;
                scaleButton.GetComponent<Image>().color = Color.white;
                deleteButton.GetComponent<Image>().color = Color.white;
            }
        }

        else if (leftRightOn == true)
        {
            leftRightOn = false;
            upDownOn = false;
            rotateOn = false;
            scaleOn = false;
            deleteOn = false;
            if (!leftRightOn)
            {
                leftRightButton.GetComponent<Image>().color = Color.white;
                upDownButton.GetComponent<Image>().color = Color.white;
                rotateButton.GetComponent<Image>().color = Color.white;
                scaleButton.GetComponent<Image>().color = Color.white;
                deleteButton.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void upDownPress()
    {
        if (upDownOn == false)
        {
            leftRightOn = false;
            upDownOn = true;
            rotateOn = false;
            scaleOn = false;
            deleteOn = false;
            if (upDownOn)
            {
                leftRightButton.GetComponent<Image>().color = Color.white;
                upDownButton.GetComponent<Image>().color = new Color32(113, 167, 198, 255);
                rotateButton.GetComponent<Image>().color = Color.white;
                scaleButton.GetComponent<Image>().color = Color.white;
                deleteButton.GetComponent<Image>().color = Color.white;

            }
        }

        else if (upDownOn == true)
        {
            leftRightOn = false;
            upDownOn = false;
            rotateOn = false;
            scaleOn = false;
            deleteOn = false;
            if (!upDownOn)
            {
                leftRightButton.GetComponent<Image>().color = Color.white;
                upDownButton.GetComponent<Image>().color = Color.white;
                rotateButton.GetComponent<Image>().color = Color.white;
                scaleButton.GetComponent<Image>().color = Color.white;
                deleteButton.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void rotatePress()
    {
        if (rotateOn == false)
        {
            leftRightOn = false;
            upDownOn = false;
            rotateOn = true;
            scaleOn = false;
            deleteOn = false;
            if (rotateOn)
            {
                leftRightButton.GetComponent<Image>().color = Color.white;
                upDownButton.GetComponent<Image>().color = Color.white;
                rotateButton.GetComponent<Image>().color = new Color32(113, 167, 198, 255);
                scaleButton.GetComponent<Image>().color = Color.white;
                deleteButton.GetComponent<Image>().color = Color.white;

            }
        }

        else if (rotateOn == true)
        {
            leftRightOn = false;
            upDownOn = false;
            rotateOn = false;
            scaleOn = false;
            deleteOn = false;
            if (!rotateOn)
            {
                leftRightButton.GetComponent<Image>().color = Color.white;
                upDownButton.GetComponent<Image>().color = Color.white;
                rotateButton.GetComponent<Image>().color = Color.white;
                scaleButton.GetComponent<Image>().color = Color.white;
                deleteButton.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void scalePress()
    {
        if (scaleOn == false)
        {
            leftRightOn = false;
            upDownOn = false;
            rotateOn = false;
            scaleOn = true;
            deleteOn = false;
            if (scaleOn)
            {
                leftRightButton.GetComponent<Image>().color = Color.white;
                upDownButton.GetComponent<Image>().color = Color.white;
                rotateButton.GetComponent<Image>().color = Color.white;
                scaleButton.GetComponent<Image>().color = new Color32(113, 167, 198, 255);
                deleteButton.GetComponent<Image>().color = Color.white;
            }
        }

        else if (scaleOn == true)
        {
            leftRightOn = false;
            upDownOn = false;
            rotateOn = false;
            scaleOn = false;
            deleteOn = false;
            if (!scaleOn)
            {
                leftRightButton.GetComponent<Image>().color = Color.white;
                upDownButton.GetComponent<Image>().color = Color.white;
                rotateButton.GetComponent<Image>().color = Color.white;
                scaleButton.GetComponent<Image>().color = Color.white;
                deleteButton.GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void deletePress()
    {
        if (deleteOn == false)
        {
            leftRightOn = false;
            upDownOn = false;
            rotateOn = false;
            scaleOn = false;
            deleteOn = true;
            if (deleteOn)
            {
                leftRightButton.GetComponent<Image>().color = Color.white;
                upDownButton.GetComponent<Image>().color = Color.white;
                rotateButton.GetComponent<Image>().color = Color.white;
                scaleButton.GetComponent<Image>().color = Color.white;
                deleteButton.GetComponent<Image>().color = new Color32(113, 167, 198, 255);
            }
        }

        else if (deleteOn == true)
        {
            leftRightOn = false;
            upDownOn = false;
            rotateOn = false;
            scaleOn = false;
            deleteOn = false;
            if (!deleteOn)
            {
                leftRightButton.GetComponent<Image>().color = Color.white;
                upDownButton.GetComponent<Image>().color = Color.white;
                rotateButton.GetComponent<Image>().color = Color.white;
                scaleButton.GetComponent<Image>().color = Color.white;
                deleteButton.GetComponent<Image>().color = Color.white;
            }
        }
    }





}
