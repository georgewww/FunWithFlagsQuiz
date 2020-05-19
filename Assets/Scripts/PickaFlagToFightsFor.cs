using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class PickaFlagToFightsFor : MonoBehaviour {
	public static Sprite[] flagarray;
	Dropdown dropdown;

	// Use this for initialization
	void Start () {
	

//		 dropdown = GameObject.Find ("Dropdown").GetComponent <Dropdown> ();


		flagarray = Resources.LoadAll<Sprite> ("flags");


//		for (int i = 0; i < flagarray.Length; i++) {
//			
//			dropdown.options.Add(new Dropdown.OptionData(flagarray[i].name.Replace ("_"," ")));
//		}
//
	


	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ValueChanched()
	{
//		dropdown.Select ();
//		dropdown.RefreshShownValue ();
//		PlayerPrefs.SetString ("flag",dropdown.captionText.text.ToString ());
//
//		Debug.Log (PlayerPrefs.GetString ("flag"));
	}

}
