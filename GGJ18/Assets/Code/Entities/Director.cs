using Assets.Code.Helpers;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour {

	public DynamicLabel ScoreMonsters; 
	public DynamicLabel ScoreRobots; 

	private int scorePlayerRobots;
	private int scorePlayerMonsters;

	void Start () {
		scorePlayerRobots = scorePlayerMonsters = 0;
		UpdateScore();
	}

	void UpdateScore () {
		ScoreRobots.SetLabel(scorePlayerRobots);
		ScoreMonsters.SetLabel(scorePlayerMonsters);
	}

	public void AddScore(Faction fac){
		scorePlayerMonsters = fac == Faction.Monsters ? scorePlayerMonsters++ : scorePlayerMonsters;
		scorePlayerRobots = fac == Faction.Robot ? scorePlayerRobots++ : scorePlayerRobots;
		UpdateScore();
	}
}
