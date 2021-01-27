using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighlightScript : MonoBehaviour {

    // Controls the highlights of the object icons. (Because of the way the 'scripts as gameobjects' design I used, I have to link these objects by script)

    public GameObject snowS;
    public GameObject snowL;
    public GameObject snowDust;
    public GameObject icicle;
    public GameObject crystal;
    public GameObject iceGroup;
    public GameObject iceRow;
    public GameObject iceHole;
    public GameObject bear;
    public GameObject snowman;
    public GameObject statue;
    public GameObject tree;
    public GameObject rock;
	
    public GameObject snowSHL;
    public GameObject snowLHL;
    public GameObject snowDustHL;
    public GameObject icicleHL;
    public GameObject crystalHL;
    public GameObject iceGroupHL;
    public GameObject iceRowHL;
    public GameObject iceHoleHL;
    public GameObject bearHL;
    public GameObject snowmanHL;
    public GameObject statueHL;
    public GameObject treeHL;
    public GameObject rockHL;


	// Update is called once per frame
	void Update () {

        snowSHL.SetActive(false);
        snowLHL.SetActive(false);
        snowDustHL.SetActive(false);
        icicleHL.SetActive(false);
        crystalHL.SetActive(false);
        iceGroupHL.SetActive(false);
        iceRowHL.SetActive(false);
        iceHoleHL.SetActive(false);
        bearHL.SetActive(false);
        snowmanHL.SetActive(false);
        statueHL.SetActive(false);
        treeHL.SetActive(false);
        rockHL.SetActive(false);
		
        if (snowS.active){
            snowSHL.SetActive(true);
        }

        if (snowL.active){
            snowLHL.SetActive(true);
        }

        if (snowDust.active)
        {
            snowDustHL.SetActive(true);
        }

        if (icicle.active)
        {
            icicleHL.SetActive(true);
        }

        if (crystal.active)
        {
            crystalHL.SetActive(true);
        }

        if (iceGroup.active)
        {
            iceGroupHL.SetActive(true);
        }

        if (iceRow.active)
        {
            iceRowHL.SetActive(true);
        }

        if (iceHole.active)
        {
            iceHoleHL.SetActive(true);
        }

        if (bear.active)
        {
            bearHL.SetActive(true);
        }

        if (snowman.active)
        {
            snowmanHL.SetActive(true);
        }

        if (statue.active)
        {
            statueHL.SetActive(true);
        }

        if (tree.active)
        {
            treeHL.SetActive(true);
        }

        if (rock.active)
        {
            rockHL.SetActive(true);
        }
	}
}
