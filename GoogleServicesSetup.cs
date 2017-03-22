using UnityEngine;
using System.Collections;
#if UNITY_ANDROID
using GooglePlayGames;
using GooglePlayGames.BasicApi;
//using UnityEngine.SocialPlatforms;

#endif

public class GoogleServicesSetup : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{	
		#if UNITY_ANDROID
			
		// recommended for debugging:
		PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate ();
		#endif

		AuthenticateUser ();

		GetComponent<Button> ().onClick.AddListener (AuthenticateUser);

	}



	public void AuthenticateUser ()
	{
	
		if (Social.localUser.authenticated)
			return;

		// authenticate user:
		Social.localUser.Authenticate ((bool success) => {
			// handle success or failure
			Debug.Log ("Google Services Authenticate: " + success);
		});


	}

	public void ShowArchivement ()
	{

		if (Social.localUser.authenticated) {
		
			Social.ShowAchievementsUI ();
		} else {
		
			Debug.Log ("Social.localUser.authenticated fail, not show archivement");

			AuthenticateUser ();

		}

	}






}
