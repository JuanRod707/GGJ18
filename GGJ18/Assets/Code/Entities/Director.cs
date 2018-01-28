using Assets.Code.Helpers;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour {

	public DynamicLabel ScoreMonsters; 
	public DynamicLabel ScoreRobots; 
	public DynamicLabel Timer;
	public float MatchLength;
	private int scorePlayerRobots;
	private int scorePlayerMonsters;
	private float matchTimer;

	void Start () {
		scorePlayerRobots = scorePlayerMonsters = 1;
		matchTimer = MatchLength;
		Timer.SetLabel(MatchLength);
		UpdateScore();
	}
	void Update(){
		UpdateTimer();
		matchTimer -= Time.deltaTime;
		if(matchTimer < 0){
			EndGame();
		}
	}
	void UpdateTimer(){
		Timer.SetLabel(matchTimer.ToString("N0"));
	}
	void UpdateScore () {
		ScoreRobots.SetLabel(scorePlayerRobots);
		ScoreMonsters.SetLabel(scorePlayerMonsters);
	}

	public void AddScore(Faction fac){
		switch (fac){
			case Faction.Monsters:
				scorePlayerMonsters++;
			break;
			case Faction.Robot:
				scorePlayerRobots++;
			break;

		}

		UpdateScore();
	}
	public void SubstractScore(Faction fac){
		switch (fac){
			case Faction.Monsters:
				scorePlayerMonsters--;
			break;
			case Faction.Robot:
				scorePlayerRobots--;
			break;

		}

		UpdateScore();
	}
	private void EndGame(){
		string theWinner ="";
		theWinner = scorePlayerMonsters > scorePlayerRobots ? "THE MONSTERS!!!" : "THE ROBOTS!!!";
		theWinner = scorePlayerMonsters == scorePlayerRobots ? "ITS A TIE" : theWinner;
		Debug.Log("--------------------GAME END--------------------");
		Debug.Log("--------------------AND THE WINNER IS--------------------");
		Debug.Log(string.Format("--------------------{0}--------------------", theWinner));
	}
}
