using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAction : MonoBehaviour {

public float TimeToRespawn;
	public GameObject PointSpawnPlayer;

	private HealthComponent health;
	void Start () {
		health = this.GetComponent<HealthComponent>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!health.IsAlive)
		{
			StartCountdownSpawn();
			SendMeToHeaven();
		}
	}
	private IEnumerator StartCountdownSpawn(){
		yield return new WaitForSeconds(TimeToRespawn);
		RespawnPlayer();
	}
	private void RespawnPlayer(){
		this.gameObject.SetActive(true);
		this.gameObject.transform.position = PointSpawnPlayer.transform.position;
	}
	private void SendMeToHeaven(){
		this.gameObject.SetActive(false);
	}
}
