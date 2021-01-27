using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HomeUIController : MonoBehaviour {

    public void MainClick(){
        SceneManager.LoadScene("Main");
    }

    public void SculptureClick(){
        SceneManager.LoadScene("IceSculpture2");
    }

    public void LibraryClick(){
        SceneManager.LoadScene("Library");
    }
}
