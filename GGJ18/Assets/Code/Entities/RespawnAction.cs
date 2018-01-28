using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAction : MonoBehaviour {

public float TimeToRespawn;
	public Transform PointSpawnPlayer;
    
	public void Respawn(){
		this.gameObject.SetActive(true);
		this.gameObject.transform.position = PointSpawnPlayer.position;
	    this.GetComponent<HealthComponent>().FullHeal();
	}

	public void Kill()
	{
	    var dir = GameObject.Find("Director").GetComponent<Director>();
	    dir.StartRespawnRoutine(this, TimeToRespawn);
	    this.gameObject.SetActive(false);
    }
}
