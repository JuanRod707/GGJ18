using System.Linq;
using Assets.Code.Entities;
using UnityEngine;

public class DetectProximity : MonoBehaviour {

    public string[] EnemyTags;

    private ReactToEnemy reactToEnemy;

	void Start () {
	    reactToEnemy = GetComponentInParent<ReactToEnemy>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (EnemyTags.Contains(other.tag))
        {
            reactToEnemy.React(other.transform);
        }
    }
}
