using System.Collections.Generic;
using Assets.Code.Entities;
using UnityEngine;

public class EntityDetector : MonoBehaviour
{
    public List<GameObject> EntitiesInsideTrigger;
    private PlayerFactionComponent playerFactionComponent;

    private void Start()
    {
        EntitiesInsideTrigger = new List<GameObject>();
        playerFactionComponent = GetComponentInParent<PlayerFactionComponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var isNpc = other.CompareTag(Constants.tagNpcs);
        var isMinion = other.CompareTag(Constants.tagMinion);
        var minionIsFromDifferentFaction = other.gameObject.GetComponent<Minion>() != null &&
                                           other.gameObject.GetComponent<Minion>().Faction !=
                                           playerFactionComponent.PlayerFaction;
        var isDIfferentFactionMinion = isMinion && minionIsFromDifferentFaction;
        var isPlayer = other.CompareTag(Constants.tagPlayer) &&
                       playerFactionComponent.PlayerFaction !=
                       other.gameObject.GetComponentInParent<PlayerFactionComponent>().PlayerFaction;
        if (isNpc || isDIfferentFactionMinion || isPlayer)
        {
            EntitiesInsideTrigger.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EntitiesInsideTrigger.Remove(other.gameObject);
    }
}