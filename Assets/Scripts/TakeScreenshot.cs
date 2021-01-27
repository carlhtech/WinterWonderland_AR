using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TakeScreenshot : MonoBehaviour
{


    public Button cameraButton;
    private Sprite screenshotTaken;

    public GameObject whiteScreen;
    public GameObject takenText;



    void Start()
    {
        Button btn = cameraButton.GetComponent<Button>();
        btn.onClick.AddListener(Screenshot);
    }


    public void Screenshot()
    {
       

        StartCoroutine(Shutter());


        int allowedScreenshots = 10;

        for (int i = 0; i <= allowedScreenshots; i++)
        {
            if (!File.Exists(Application.persistentDataPath + "/Screenshot" + i + ".png"))
            {
                ScreenCapture.CaptureScreenshot("/Screenshot" + i + ".png");
                return;
            }
        }

    }

    IEnumerator Shutter(){
        yield return new WaitForSeconds(0.2f);
        whiteScreen.SetActive(true);
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        yield return new WaitForSeconds(0.1f);
        whiteScreen.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        takenText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        takenText.SetActive(false);
    }


}