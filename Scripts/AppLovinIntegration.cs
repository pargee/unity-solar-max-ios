using UnityEngine;
using System.Collections;

public class AppLovinIntegration : MonoBehaviour {
	private static AppLovinIntegration _instance;
	
	public static AppLovinIntegration instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<AppLovinIntegration>();
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		if(_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			if(this != _instance)
				Destroy(this.gameObject);
		}
	}
	
	void Start () {
		AppLovin.SetSdkKey ("APPLOVIN KEY HERE");
		AppLovin.InitializeSdk ();
		AppLovin.SetUnityAdListener (this.name);

		AppLovin.ShowAd(AppLovin.AD_POSITION_CENTER, AppLovin.AD_POSITION_BOTTOM);
	}
	
	
	void Update () {
	
	}
	
	void onAppLovinEventReceived(string ev)
	{
		if( string.Equals(ev, "DISPLAYEDINTER") || string.Equals(ev, "VIDEOBEGAN") )
		{
			Time.timeScale = 0.0f;
			AudioListener.pause = true;
		}
		
		if( string.Equals(ev, "HIDDENINTER") )
		{
			Time.timeScale = 1.0f;
			AudioListener.pause = false;
			AppLovin.ShowAd();
			
		}
	}


}
