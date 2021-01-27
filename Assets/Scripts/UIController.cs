using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {


    public GameObject canvasMain;
    public GameObject canvasMenu;
    public GameObject canvasAdd;
    public GameObject canvasIceSub;
    public GameObject canvasSnowSub;
    public GameObject canvasEditor;
    public GameObject canvasOutsideSub;
    public GameObject canvasAnimalSub;
    public GameObject canvasOtherSub;

    public GameObject[] scripts;

    public GameObject exitButton;

    private bool subMenuActive = false;


    public void Update()
    {
        if(!canvasMenu.active && !canvasAdd.active){
            exitButton.SetActive(false);
            //canvasEditor.SetActive(false);
        }

        if(canvasMenu.active){
            canvasEditor.SetActive(false);
        }

    }

    public void ExitClick(){
        if(canvasMenu){
            canvasMenu.SetActive(false);
            canvasMain.SetActive(true);
            canvasEditor.SetActive(false);
        }
        if(canvasAdd){
            canvasAdd.SetActive(false);
            canvasMain.SetActive(true);
            canvasEditor.SetActive(false);
            canvasSnowSub.SetActive(false);
            canvasIceSub.SetActive(false);
            canvasOutsideSub.SetActive(false);
            canvasAnimalSub.SetActive(false);
            canvasOtherSub.SetActive(false);
        }
    }

    // Main menu buttons

    public void MenuClick(){
        canvasMain.SetActive(false);
        canvasMenu.SetActive(true);
        exitButton.SetActive(true);
    }

    public void AddClick(){
        canvasMain.SetActive(false);
        canvasAdd.SetActive(true);
        canvasEditor.SetActive(true);
        exitButton.SetActive(true);
    }

    public void EditClick(){
        if (canvasEditor.active){
            canvasEditor.SetActive(false);
        }
        else {
            canvasEditor.SetActive(true);
        }
    }

    // Menu sub menu

    public void HomeClick(){
        SceneManager.LoadScene("Menu");
    }

    // Add sub menus

    public void SnowClick(){
        canvasIceSub.SetActive(false);
        canvasOutsideSub.SetActive(false);
        canvasAnimalSub.SetActive(false);
        canvasOtherSub.SetActive(false);
        canvasSnowSub.SetActive(true);
    }

    public void IceClick(){
        canvasSnowSub.SetActive(false);
        canvasOutsideSub.SetActive(false);
        canvasAnimalSub.SetActive(false);
        canvasOtherSub.SetActive(false);
        canvasIceSub.SetActive(true);
    }

    public void OutsideClick()
    {
        canvasIceSub.SetActive(false);
        canvasSnowSub.SetActive(false);
        canvasAnimalSub.SetActive(false);
        canvasOtherSub.SetActive(false);
        canvasOutsideSub.SetActive(true);
    }

    public void AnimalClick()
    {
        canvasIceSub.SetActive(false);
        canvasSnowSub.SetActive(false);
        canvasOutsideSub.SetActive(false);
        canvasOtherSub.SetActive(false);
        canvasAnimalSub.SetActive(true);
    }

    public void OtherClick()
    {
        canvasIceSub.SetActive(false);
        canvasSnowSub.SetActive(false);
        canvasOutsideSub.SetActive(false);
        canvasAnimalSub.SetActive(false);
        canvasOtherSub.SetActive(true);
    }

    // Snow Items

    public void SnowSmallClick(){
        ScriptsOff();
        scripts[0].SetActive(true);
    }

    public void SnowLargeClick()
    {
        ScriptsOff();
        scripts[6].SetActive(true);
    }

    public void SnowDustClick()
    {
        ScriptsOff();
        scripts[7].SetActive(true);
    }



    // Ice Items

    public void IcicleClick(){
        ScriptsOff();
        scripts[1].SetActive(true);
    }

    public void CrystalClick(){
        ScriptsOff();
        scripts[2].SetActive(true);
    }

    public void IceGroupClick()
    {
        ScriptsOff();
        scripts[4].SetActive(true);
    }

    public void IceRowClick()
    {
        ScriptsOff();
        scripts[5].SetActive(true);
    }



    // Outside Items

    public void IceHoleClick(){
        ScriptsOff();
        scripts[3].SetActive(true);
    }

    // Animal Items

    public void PolarBearClick(){
        ScriptsOff();
        scripts[8].SetActive(true);
    }

    // Other Items

    public void SnowmanClick()
    {
        ScriptsOff();
        scripts[9].SetActive(true);
    }

    public void StatueClick()
    {
        ScriptsOff();
        scripts[10].SetActive(true);
    }

    public void TreeClick(){
        ScriptsOff();
        scripts[11].SetActive(true);
    }
   
    public void RockClick()
    {
        ScriptsOff();
        scripts[12].SetActive(true);
    }




    public void ScriptsOff(){
        foreach(GameObject s in scripts){
            s.SetActive(false);
        }
    }
}
