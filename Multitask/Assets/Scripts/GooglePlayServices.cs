using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class GooglePlayServices : MonoBehaviour {

	// Source
	// https://github.com/playgameservices/play-games-plugin-for-unity

	public string[] achievements = {"CgkIromiy_cEEAIQBg",	// Test Acheievement
	                              "CgkIromiy_cEEAIQBw", // Incremental
	                              "CgkIromiy_cEEAIQCA", // Test 3
	                              "CgkIromiy_cEEAIQCQ", // Test 4
								  "CgkIromiy_cEEAIQCg"};// Test 5
	public string leaderboard = "CgkIromiy_cEEAIQCw";


	// Use this for initialization
	void Start () {
		PlayGamesPlatform.Activate();

		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
			if (success) {
				Debug.Log("LoggedIN");
			}
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if (GUI.Button (new Rect (250, 250, 500, 50), "Unlock Achievement"))
		{
			Social.ReportProgress(achievements[0], 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if (GUI.Button (new Rect (250, 350, 500, 50), "Unlock Achievement Inc"))
		{
			PlayGamesPlatform.Instance.IncrementAchievement(
				achievements[1], 5, (bool success) => {
				// handle success or failure
			});
		}

		if (GUI.Button (new Rect (250, 450, 500, 50), "Add Leaderboard"))
		{
			Social.ReportScore(12345, leaderboard, (bool success) => {
				// handle success or failure
			});
		}

		if (GUI.Button (new Rect (250, 550, 500, 50), "Show Leaderboard"))
		{
			PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboard);
		}

		if (GUI.Button (new Rect (250, 650, 500, 50), "Show Achievement"))
		{
			Social.ShowAchievementsUI();
		}


	}
}
