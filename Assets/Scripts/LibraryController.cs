using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LibraryController : MonoBehaviour {

    public void HomeClick(){
        SceneManager.LoadScene("Menu");
    }

    //delete all photos from library

    private string SaveFilePath{
        get { return Application.persistentDataPath + "/Screenshot0.png"; }
    }

    private string SaveFilePath1
    {
        get { return Application.persistentDataPath + "/Screenshot1.png"; }
    }

    private string SaveFilePath2
    {
        get { return Application.persistentDataPath + "/Screenshot2.png"; }
    }

    private string SaveFilePath3
    {
        get { return Application.persistentDataPath + "/Screenshot3.png"; }
    }

    public void Delete(){
        
        File.Delete(SaveFilePath);
        File.Delete(SaveFilePath1);
        File.Delete(SaveFilePath2);
        File.Delete(SaveFilePath3);
        SceneManager.LoadScene("Library");
    }
}
