using Assets.Code.Helpers;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour {

	public DynamicLabel ScoreMonsters; 
	public DynamicLabel ScoreRobots; 

	private int scorePlayerRobots;
	private int scorePlayerMonsters;

	void Start () {
		scorePlayerRobots = scorePlayerMonsters = 1;
		UpdateScore();
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
}
