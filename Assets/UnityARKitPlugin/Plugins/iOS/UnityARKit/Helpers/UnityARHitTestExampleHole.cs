using System;
using System.Collections.Generic;

namespace UnityEngine.XR.iOS
{
    public class UnityARHitTestExampleHole : MonoBehaviour
    {

        public Animator animation;
        public Transform m_HitTransform;
        private UnityARCameraManager m_ARCameraManager;

        void Start()
        {
            m_ARCameraManager = GameObject.Find("ARCameraManager").GetComponent<UnityARCameraManager>();
        }

        bool HitTestWithResultType(ARPoint point, ARHitTestResultType resultTypes)
        {
            List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface().HitTest(point, resultTypes);
            if (hitResults.Count > 0)
            {
                foreach (var hitResult in hitResults)
                {
                    Debug.Log("Got hit!");
                    m_HitTransform.position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
                    m_HitTransform.rotation = Quaternion.LookRotation(
                        new Vector3(
                            m_ARCameraManager.m_camera.transform.localPosition.x - m_HitTransform.position.x,
                            0.0f,
                            m_ARCameraManager.m_camera.transform.localPosition.z - m_HitTransform.position.z
                        ));
                    Debug.Log(string.Format("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));
                    return true;
                }
            }
            return false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount > 0 && m_HitTransform != null)
            {
                var touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
                    ARPoint point = new ARPoint
                    {
                        x = screenPosition.x,
                        y = screenPosition.y
                    };

                    // prioritize reults types
                    ARHitTestResultType[] resultTypes = {
                        ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
                        // if you want to use infinite planes use this:
                        //ARHitTestResultType.ARHitTestResultTypeExistingPlane,
                        ARHitTestResultType.ARHitTestResultTypeHorizontalPlane,
                        ARHitTestResultType.ARHitTestResultTypeFeaturePoint
                    };

                    foreach (ARHitTestResultType resultType in resultTypes)
                    {
                        if (HitTestWithResultType(point, resultType))
                        {
                            animation.Play("Take 001", 0, 0.0f);
                            return;
                        }
                    }
                }
                if(touch.phase == TouchPhase.Moved){
                    m_HitTransform.transform.Rotate(0f, touch.deltaPosition.x, 0f);
                }
            }
        }


    }
}
