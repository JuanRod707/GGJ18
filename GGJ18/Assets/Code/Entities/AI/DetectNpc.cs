using Assets.Code.Entities;
using UnityEngine;

public class DetectNpc : MonoBehaviour {

    public string RunToTag;

    private Minion myMinion;
    private ChaseNpc chaseNpc;

	void Start ()
    {
        myMinion = GetComponentInParent<Minion>();
        chaseNpc = GetComponentInParent<ChaseNpc>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(RunToTag))
        {
            chaseNpc.StartChasing(other.transform);
        }
        else if (other.CompareTag("Minion"))
        {
            var minion = other.GetComponentInParent<Minion>();
            if (minion.Faction != myMinion.Faction)
            {
                chaseNpc.StartChasing(other.transform);
            }
        }
    }
}
