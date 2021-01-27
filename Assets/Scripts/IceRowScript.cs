using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;
using UnityEngine.EventSystems;

public class IceRowScript : MonoBehaviour
{

    public GameObject iceRow;



    void CreateRow(Vector3 atPosition)
    {
        Instantiate(iceRow, atPosition, Quaternion.identity);
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
            if ((touch.phase == TouchPhase.Ended) && !IsPointerOverUIObject())
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

                        CreateRow(new Vector3(position.x, position.y, position.z));
                        this.gameObject.SetActive(false);
                        break;
                    }
                }
            }

        }

    }

}
