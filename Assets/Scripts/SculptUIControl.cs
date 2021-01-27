using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SculptUIControl : MonoBehaviour {

    public GameObject vertices;
    public GameObject vertices1;
    public GameObject vertices2;
    public GameObject vertices3;

    public GameObject chiselMenu;

    private bool chiselActive = false;


    public void HomeClick(){
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        chiselMenu.SetActive(false);
    }


    public void LevelOnePress(){
        vertices.SetActive(true);
        vertices1.SetActive(false);
        vertices2.SetActive(false);
        vertices3.SetActive(false);
    }

    public void LevelTwoPress()
    {
        vertices.SetActive(false);
        vertices1.SetActive(true);
        vertices2.SetActive(false);
        vertices3.SetActive(false);
    }

    public void LevelThreePress()
    {
        vertices.SetActive(false);
        vertices1.SetActive(false);
        vertices2.SetActive(true);
        vertices3.SetActive(false);
    }

    public void LevelFourPress()
    {
        vertices.SetActive(false);
        vertices1.SetActive(false);
        vertices2.SetActive(false);
        vertices3.SetActive(true);
    }

    public void ChiselPress(){
        if(chiselActive == false){
            chiselMenu.SetActive(true);
            chiselActive = true;
        }else{
            chiselMenu.SetActive(false);
            chiselActive = false;
        }
    }
}
