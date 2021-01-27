using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.EventSystems;

public class BallMaker : MonoBehaviour {

	public GameObject ballPrefab;
    public GameObject ball2;

    private bool button1Pressed = false;
    private bool button2Pressed = false;

    private float instantiationTimer = 0.2f;

    public void button1(){
        if (button1Pressed == false){
            button1Pressed = true;
        }else{
            button1Pressed = false;
        }
    } 

    public void button2(){
        if (button2Pressed == false){
            button2Pressed = true;
        }else{
            button2Pressed = false;
        }
    } 


	void CreateBall(Vector3 atPosition)
	{
		GameObject ballGO = Instantiate (ballPrefab, atPosition, Quaternion.identity);
	}

    void CreateBall2(Vector3 atPosition)
    {
        GameObject ballGO2 = Instantiate(ball2, atPosition, Quaternion.identity);
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
		if (Input.touchCount > 0 )
		{
			var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved && !IsPointerOverUIObject())
			{
				var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
                ARPoint point = new ARPoint { x = screenPosition.x, y = screenPosition.y };
					
						
				List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, 
					ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);
				if (hitResults.Count > 0) {
					foreach (var hitResult in hitResults) {
						Vector3 position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);

                        instantiationTimer -= Time.deltaTime;
                        if (instantiationTimer <= 0)
                        {
                            if (button1Pressed)
                            {
                                CreateBall(new Vector3(position.x, position.y, position.z));
                                instantiationTimer = 0.2f;
                            }
                            if (button2Pressed)
                            {
                                CreateBall2(new Vector3(position.x, position.y, position.z));
                            }
                            break;
                        }
					}
				}

			}
		}

	}

}
