using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Scene());
	}
	
    IEnumerator Scene(){
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadScene("Menu");
    }
}
