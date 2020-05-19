
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class Level1ControllerCanvas : MonoBehaviour {

	[SerializeField] private AudioClip backgroundMusic; // The music clip you want to play. The [SerializeField] tag specifies that this variable is viewable in Unity's inspector. I prefer not to use public variables if I can get away with using private ones.

	private AudioSource _audio; // The reference to my AudioSource (look in the Start() function for more details)

	// Use this for initialization
	void Start () {
		_audio = GetComponent<AudioSource>();
		RequestBanner ();
		// We set the audio clip to play as your background music.
	//	_audio.clip = backgroundMusic;
	}

	public void SoundClick()
	{
		// Check if the music is currently playing.
		if(_audio.isPlaying)
			_audio.Pause(); // Pause if it is
		else
			_audio.Play(); // Play if it isn't
	}

	public void ButtonHome()
	{
		SceneManager.LoadScene ("MAIN");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private void RequestBanner()
	{
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-8082833543560767/1698139737";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		BannerView bannerView = new BannerView (adUnitId, AdSize.SmartBanner, AdPosition.Top);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd (request);

	}

}
