using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public AudioClip[] userInterfaceSounds;
	public AudioClip[] gameplaySounds;
	public AudioClip[] playerSounds;

	private bool soundOn = true;


	private AudioSource audioSource;
	private static SoundManager _instance;
	
	public static SoundManager instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<SoundManager>();
				
				
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
		audioSource.PlayOneShot (audioClip);	
	}

	public void ToggleSound() {
		if (soundOn) {
			AudioListener.pause = true;
			soundOn = false;

		} else {
			AudioListener.pause = false;
			soundOn = true;

		}
	}

}