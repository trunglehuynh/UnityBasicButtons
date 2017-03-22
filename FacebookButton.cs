using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FacebookButton : MonoBehaviour {

	// Use this for initialization
	string fbApp ="fb://Your-FaceBook-page/“; 				// replace your facebook page here
	string fbLink="https://www.facebook.com/Your-FaceBook-page/";		// replace your facebook page here
	void Start () {
	
		GetComponent<Button> ().onClick.AddListener (FacebButton);
	}


	void FacebButton ()
	{
		float startTime;
		startTime = Time.timeSinceLevelLoad;

		//open the facebook app
		Application.OpenURL(fbApp);

		if (Time.timeSinceLevelLoad - startTime <= 1f)
		{
			//fail. Open safari.
			Application.OpenURL(fbLink);
		}

		SoundManager.current.playButtonSound ();

	}
}
