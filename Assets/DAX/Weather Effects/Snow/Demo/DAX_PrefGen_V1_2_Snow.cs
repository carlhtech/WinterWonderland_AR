using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DAX_PrefGen_V1_2_Snow : MonoBehaviour 
{
	public GameObject[] Items;
	public string[] Descr;
	public Text OutText;
	public Text OutDescr;
	public int curIndex = 0;
	

	GameObject tmpPref; 

	void Awake()
	{
		showPrefab();
	}

	void FixedUpdate () 
	{
		this.OutText.text = string.Format( "{0}/{1}", this.curIndex+1, this.Items.Length );
	}

	void Update()
	{

	}

	public void Next()
	{
		this.curIndex += 1;
		if (this.curIndex >= this.Items.Length )
		{
			this.curIndex = 0;
		}
		showPrefab();
		//Application.LoadLevel( );
		
	}

	public void Prev()
	{
		this.curIndex -= 1;
		if (this.curIndex <0) { this.curIndex = this.Items.Length-1;};
		showPrefab();
	}

	public void  showPrefab( )
	{
		if (tmpPref!=null) 
		{ 
			GameObject.DestroyObject( tmpPref ); 
		}	
		Vector3 StandardOffset = new Vector3(0.0f,0.0f,0.0f);
		tmpPref = Instantiate( this.Items[ this.curIndex ], StandardOffset, Quaternion.identity) as GameObject;	
		
	}
	
	

}
