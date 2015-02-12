using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class SocialAPI : MonoBehaviour 
{
	private static SocialAPI _instance;
	
	public static SocialAPI instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<SocialAPI>();
				
				
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

	public bool isAuthenticated = false;
	public bool showSocialWindow = false;
	public bool loadScores = false;
	public bool showLeaderboard = false;
	
	
	void Start () 
	{
		/* Don't do it using a block (unity sample code) becasue if one user logs out
		 * and another user logs in the callback will not
		 * be invoked for the second user.
		 * 
		 * Also if the user logs out and comes back to the game the 
		 * logout will not be handled
		 * 
		 * Social.localUser.Authenticate (success => {
   			 if (success) {
        	Debug.Log ("Authentication successful");
        	string userInfo = "Username: " + Social.localUser.userName + 
            "\nUser ID: " + Social.localUser.id + 
            "\nIsUnderage: " + Social.localUser.underage;
        	Debug.Log (userInfo);
    	}
    	else
        Debug.Log ("Authentication failed");
		} );

		*/
		
		Social.localUser.Authenticate (ProcessAuthentication);
		
	}
	
	void ProcessAuthentication (bool a_success)
	{
		if (a_success) 
		{
			isAuthenticated = true;
		}
		else
		{
			isAuthenticated = false;
		}
		
		Debug.Log("SocialAPI: isAuthenticated=" + isAuthenticated + 
		          ", userName=" + Social.localUser.userName +
		          ", id=" + Social.localUser.id +
		          ", underage=" + Social.localUser.underage);
	}
	
	
	void Update()
	{
		if (showSocialWindow)
		{
			showSocialWindow = false;
			Social.LoadAchievements (ProcessLoadAchievements);
		}
		
		if (loadScores)
		{
			loadScores = false;
			Social.LoadScores(Literals.lDefaultLeaderboard, HandleLoadScores);
		}
		
		if (showLeaderboard)
		{
			showLeaderboard = false;
			Social.ShowLeaderboardUI ();
		}
	}
	
	void HandleLoadScores(IScore[] a_scores)
	{
		if (a_scores.Length > 0) 
		{
			Debug.Log ("Got " + a_scores.Length + " scores");
			
			// Build your own leader board
			
		}
		else
		{
			Debug.Log ("No scores loaded");
		}
	}
	
	
	void ProcessLoadAchievements(IAchievement[] a_achievements)
	{
		if (a_achievements.Length > 0) 
		{
			Debug.Log ("Got " + a_achievements.Length + " achievement instances");
			string myAchievements = "My achievements:\n";
			foreach (IAchievement achievement in a_achievements)
			{
				myAchievements += "\t" + 
					achievement.id + " " +
						achievement.percentCompleted + " " +
						achievement.completed + " " +
						achievement.lastReportedDate + "\n";
			}
			Debug.Log (myAchievements);
		}
		else
		{
			Debug.Log ("No achievements returned");
		}
		
		if (false)
		{
			// Roll your own achievement UI
		}
		else
		{
			Social.ShowAchievementsUI();
		}
	}
	
	
	void OnGUI () 
	{
		/*
		if (GUI.Button(new Rect(5, Screen.height - 32, 100, 20), "Achievement"))
		{
			showSocialWindow = true;
		}
		
		if (GUI.Button(new Rect(5, Screen.height - 54, 100, 20), "Scores"))
		{
			loadScores = true;
		}
		
		if (GUI.Button(new Rect(5, Screen.height - 76, 100, 20), "Leaderboard"))
		{
			showLeaderboard = true;
		}
		*/
	}
}
