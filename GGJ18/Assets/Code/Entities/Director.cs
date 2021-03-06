﻿using System.Collections;
using Assets.Code.Helpers;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour {
	public GameObject FinalCanvas;
	public GameObject[] Players;
	public DynamicLabel ScoreMonsters; 
	public DynamicLabel ScoreRobots; 
	public DynamicLabel Timer;
	public DynamicLabel WinnerText; 
	public float MatchLength;
	private int scorePlayerRobots;
	private int scorePlayerMonsters;
	private float matchTimer;
	private bool isGameOver;

	void Start () {
		scorePlayerRobots = scorePlayerMonsters = 1;
		matchTimer = MatchLength;
		Timer.SetLabel(MatchLength);
		UpdateScore();
	}
	void Update(){
		if(!isGameOver)
		{
			UpdateTimer();
			if(matchTimer >= 0)
				matchTimer -= Time.deltaTime;
			if(matchTimer < 0){
				isGameOver = true;
				EndGame();
			}
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

    public void StartRespawnRoutine(RespawnAction playerToRespawn, float delay)
    {
        StartCoroutine(DelayedRespawn(playerToRespawn, delay));
    }

    private void EndGame(){
		string theWinner ="";
		theWinner = scorePlayerMonsters > scorePlayerRobots ? "THE MONSTERS" : "THE ROBOTS";
		theWinner = scorePlayerMonsters == scorePlayerRobots ? "NO ONE... ITS A TIE" : theWinner;
		WinnerText.SetLabel(theWinner);
		FinalCanvas.SetActive(true);

	    foreach (var p in Players)
	    {
	        p.SetActive(false);
	    }
	}

    private IEnumerator DelayedRespawn(RespawnAction playerToRespawn, float delay)
    {
        yield return new WaitForSeconds(delay);
        RespawnPlayer(playerToRespawn);
    }

    private void RespawnPlayer(RespawnAction playerToRespawn)
    {
        playerToRespawn.Respawn();
    }
}
