using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShareButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		GetComponent<Button> ().onClick.AddListener (SharingButton);
	}
		
	public void SharingButton ()
	{
		string appName =“Your-App-Name”;
		string messa = “type cool something, include your app URL”;

		#if UNITY_ANDROID

		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
		intentObject.Call<AndroidJavaObject> ("setAction", intentClass.GetStatic<string> ("ACTION_SEND"));
		intentObject.Call<AndroidJavaObject> ("setType", "text/plain");
		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_SUBJECT"), appName);
		intentObject.Call<AndroidJavaObject> ("putExtra", intentClass.GetStatic<string> ("EXTRA_TEXT"), messa);
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
		currentActivity.Call ("startActivity", intentObject);

		#endif

		#if UNITY_IOS

		GeneralSharingiOSBridge.ShareSimpleText (messa);

		#endif 

		SoundManager.current.playButtonSound ();

	}
}
