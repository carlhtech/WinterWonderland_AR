using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuControl : MonoBehaviour {

    public void ScenePress(){
        SceneManager.LoadScene("Main");
    }

    public void IceCubePress()
    {
        StartCoroutine(SculptScene());
    }

    public void LibraryPress()
    {
        StartCoroutine(LibraryScene());
    }

    public void HowToPress(){
        SceneManager.LoadScene("HowTo");
    }


    IEnumerator SculptScene(){
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("IceSculpture2");
    }

    IEnumerator LibraryScene()
    {
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("Library");
    }
}
