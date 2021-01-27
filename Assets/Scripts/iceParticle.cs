using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceParticle : MonoBehaviour {

    public GameObject particle;
    public GameObject iceBlock;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if(hit.collider != null){
                        Instantiate(particle, hit.point, Quaternion.identity);
                        StartCoroutine(StopParticle());
                    }
                }
            }
        }
	}

    IEnumerator StopParticle(){
        yield return new WaitForSeconds(0.2f);
        Destroy(particle);
    }
}
