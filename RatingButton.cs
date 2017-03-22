using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class RatingButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		GetComponent<Button> ().onClick.AddListener (ratingButton);

	}
	void ratingButton(){
		
		#if UNITY_ANDROID
		Application.OpenURL("market://details?id=com.CompanyName.AppName”);
		#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/Your-App-Name/Your-App-ID”);
		#endif
		Debug.Log ("rating button");
		SoundManager.current.playButtonSound ();

	}
	

}
