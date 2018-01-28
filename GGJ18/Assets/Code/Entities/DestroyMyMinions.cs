using System.Collections;
using System.Collections.Generic;
using Assets.Code.Entities;
using Assets.Code.Helpers;
using UnityEngine;
using System.Linq;

public class DestroyMyMinions : MonoBehaviour {
	
	public void DestroyMinions(Faction fac, int porcentaje){
		var lstMinions = this.GetComponentsInChildren<Minion>().Where(x => x.Faction == fac);
		var toTake = (lstMinions.Count() * porcentaje) / 100;
		var minionsToKill = lstMinions.Take(toTake);
		foreach(var i in minionsToKill){
			i.RecieveDamage(i.HitPoints);
		}
	}
}
