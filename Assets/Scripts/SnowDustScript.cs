using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.EventSystems;

public class SnowDustScript : MonoBehaviour
{

    public GameObject[] smallDustModels;

    private float instantiationTimer = 0.05f;




    void CreateSnow(Vector3 atPosition)
    {
        Instantiate(smallDustModels[Random.Range(0, smallDustModels.Length)], atPosition, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
    }



    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if ((touch.phase == TouchPhase.Moved) && !IsPointerOverUIObject())
            {
                var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
                ARPoint point = new ARPoint { x = screenPosition.x, y = screenPosition.y };


                List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface().HitTest(point,
                    ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);
                if (hitResults.Count > 0)
                {
                    foreach (var hitResult in hitResults)
                    {
                        Vector3 position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);

                        instantiationTimer -= Time.deltaTime;
                        if (instantiationTimer <= 0)
                        {
                            CreateSnow(new Vector3(position.x, position.y, position.z));
                            instantiationTimer = 0.05f;
                            break;
                        }
                    }
                }

            }
        }

    }

}


