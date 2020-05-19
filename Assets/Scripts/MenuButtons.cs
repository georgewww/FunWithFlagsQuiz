
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

using UnityEngine.UI;

public class MenuButtons: MonoBehaviour {
	

	// Use this for initialization
	void Start () {


	
		PlayGamesPlatform.Activate();



		// authenticate user:
		Social.localUser.Authenticate((bool success) => Debug.Log (success.ToString ()));


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonStart()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void ButtonExit()
	{
		Application.Quit();

	//	Social.ShowAchievementsUI ();
	}

	public void ButtonScore()
	{
		// show leaderboard UI
		Social.ShowLeaderboardUI();
	}

}
