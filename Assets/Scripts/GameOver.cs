using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	string myscore = "0";

	// Use this for initialization
	void Start () {
		
		myscore = PlayerPrefs.GetString ("score");


		GameObject.Find ("score").GetComponent <Text> ().text = myscore;

	

	//	yield return new WaitForSeconds(5);

	}

	public void MyButton()
	{
		SceneManager.LoadScene ("Main");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
