using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour 
{
	private AudioSource audioSource;
	private static MusicManager _instance;
	private bool soundOn = true;
	
	public static MusicManager instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<MusicManager>();
				
				
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
		audioSource = gameObject.GetComponent<AudioSource> ();
	}
	
	public void Play(AudioClip audioClip)
	{
		audioSource.clip = audioClip;
		audioSource.Play ();
	}

	public void ToggleMusic() {
		if (soundOn) {
			audioSource.mute = true;
			soundOn = false;
			
		} else {
			audioSource.mute = false;
			soundOn = true;
			
		}
	}
}