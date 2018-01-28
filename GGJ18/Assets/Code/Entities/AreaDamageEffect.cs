using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamageEffect : MonoBehaviour
{
    public List<GameObject> EntitiesInsideTrigger;
    public float SecondsBeforeEffectStarts = 2;

    private void Start()
    {
        EntitiesInsideTrigger = new List<GameObject>();
    }

    public void ActivateEffect()
    {
//        yield return new WaitForSeconds(SecondsBeforeEffectStarts);
        EntitiesInsideTrigger.RemoveAll(x => x == null);
        foreach (var entity in EntitiesInsideTrigger)
        {
            if (!entity.CompareTag(Constants.tagPlayer))
            {
                // TODO handle npc and minion cases.
                Destroy(entity);
            }
        }
        EntitiesInsideTrigger.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        EntitiesInsideTrigger.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        EntitiesInsideTrigger.Remove(other.gameObject);
    }
}