using System.Linq;
using Assets.Code.Entities;
using UnityEngine;

public class DetectNpc : MonoBehaviour {

    public string[] TagsToChase;

    private Minion myMinion;
    private ChaseNpc chaseNpc;

	void Start ()
    {
        myMinion = GetComponentInParent<Minion>();
        chaseNpc = GetComponentInParent<ChaseNpc>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (TagsToChase.Contains(other.tag))
        {
            var chase = true;
            var minion = other.GetComponentInParent<Minion>();
            var player = other.GetComponentInParent<PlayerFactionComponent>();

            if (minion != null)
            {
                if (minion.Faction == myMinion.Faction)
                {
                    chase = false;
                }
            }
            else if (player != null)
            {
                if (player.PlayerFaction == myMinion.Faction)
                {
                    chase = false;
                }
            }

            if (chase)
            {
                chaseNpc.StartChasing(other.transform.parent);
            }
        }
    }
}
