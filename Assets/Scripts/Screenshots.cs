using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Screenshots : MonoBehaviour {

    public GameObject image0;
    private Sprite sprite0;

    public GameObject image1;
    private Sprite sprite1;

    public GameObject image2;
    private Sprite sprite2;

    public GameObject image3;
    private Sprite sprite3;


	// Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if (File.Exists(Application.persistentDataPath + "/Screenshot0.png"))
        {
            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/Screenshot0.png");
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            sprite0 = sprite;
            image0.GetComponent<Image>().sprite = sprite0;
        }

       
        if (File.Exists(Application.persistentDataPath + "/Screenshot1.png"))
        {
            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/Screenshot1.png");
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            sprite1 = sprite;
            image1.GetComponent<Image>().sprite = sprite1;
        }

        if (File.Exists(Application.persistentDataPath + "/Screenshot2.png"))
        {
            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/Screenshot2.png");
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            sprite2 = sprite;
            image2.GetComponent<Image>().sprite = sprite2;
        }

        if (File.Exists(Application.persistentDataPath + "/Screenshot3.png"))
        {
            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/Screenshot3.png");
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            sprite3 = sprite;
            image3.GetComponent<Image>().sprite = sprite3;
        }
	}
}
