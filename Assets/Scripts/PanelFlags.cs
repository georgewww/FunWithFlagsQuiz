
using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;
using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.EventSystems;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class PanelFlags : MonoBehaviour {
	float t = 0;
	GameObject panel;
	GameObject CountNo;
	GameObject LifeNo;
//	FileInfo[] fileInfo;
	Sprite[] flagarray;
	Button correctbutton;
	int life = 0;
	long right = 0;
	Button mybutton;

	List<Button> buttons = new List<Button> ();

	List<Sprite> flaglist = new List<Sprite>();
	List<String> flagnames = new List<string>();

	static int sectime = 5;

	// Use this for initialization
	void Start () {
		panel = GameObject.Find("Panel");
		CountNo = GameObject.Find("CountNo");
		LifeNo = GameObject.Find("LifeNo");
	
		buttons.Add (GameObject.Find ("Button").GetComponent<Button>());
		buttons.Add (GameObject.Find ("Button (1)").GetComponent<Button>());
		buttons.Add (GameObject.Find ("Button (2)").GetComponent<Button>());
		buttons.Add (GameObject.Find ("Button (3)").GetComponent<Button>());

		 flagarray = PickaFlagToFightsFor.flagarray; //= Resources.LoadAll<Sprite> ("flags");


		for (int i = 0; i < flagarray.Length; i++) {
			flaglist.Add ((Sprite)flagarray [i]);
			flagnames.Add (flagarray[i].name);
		}

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Time.deltaTime);
		t += Time.deltaTime;

		if ( t > sectime && flaglist.Count > 0 )
		{
	//		var temp = Resources.Load<Sprite>("flags/ad");
			try{ mybutton = EventSystem.current.currentSelectedGameObject.GetComponent <Button>() as Button;}catch{};

			if (correctbutton != null) {
				if (mybutton == null) {
					life--;
				//	LifeNo.GetComponent <Text> ().text = life.ToString ();
				} else if (!correctbutton.Equals (mybutton)) {
					life--;
				//	LifeNo.GetComponent <Text> ().text = life.ToString ();
				}else{
					right++;
					LifeNo.GetComponent <Text> ().text = right.ToString ();
				}
			}

			mybutton = null;
			GameObject myEventSystem = GameObject.Find("EventSystem");
			myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

			CountNo.GetComponent <Text> ().text = flaglist.Count.ToString ();

		//	var temp2 = flaglist [Random.Range (0, flaglist.Length)];

			int randomNO = UnityEngine.Random.Range (0, flaglist.Count);

			panel.GetComponent <Image> ().sprite = (Sprite) flaglist[randomNO];
				
			t = 0;

			//flaglist.RemoveAt (randomNO);

			foreach(Button b in buttons)
			{
				b.GetComponentInChildren<Text>().text = flagnames[UnityEngine.Random.Range (0, flagarray.Length)].Replace ("_"," ");
			}

			int rightbutton = UnityEngine.Random.Range (0, 4);
			buttons [rightbutton].GetComponentInChildren<Text> ().text = flaglist [randomNO].name.Replace ("_"," ");

			flaglist.RemoveAt (randomNO);

		//	Debug.Log (panel.GetComponent <Image> ().sprite);


			correctbutton =	(Button)buttons [rightbutton];



		}


		if (flaglist.Count <= 0 ) {
			GameOver ();

		}//load score end game

	}



	public void OnClicked()
	{
		t = 6;

	}

	public void GameOver()
	{
			Time.timeScale = 0;



			// increment achievement (achievement ID "Cfjewijawiu_QA") by 5 steps
		Social.ReportScore(right, "CgkI08XEtpIJEAIQBw", (bool success) => {
				// handle success or failure
			});

//		foreach(Button b in buttons)
//		{
//			b.enabled = false;
//		//	b.GetComponentInChildren<Text>().text = flagnames[UnityEngine.Random.Range (0, flagarray.Length)].Replace ("_"," ");
//		}
		// Social.ShowLeaderboardUI ();
		PlayerPrefs.SetString ("score",right.ToString ());
		SceneManager.LoadScene ("GameOver");
	}
}
