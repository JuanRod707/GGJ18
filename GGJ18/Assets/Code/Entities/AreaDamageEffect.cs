using System.Collections;
using System.Collections.Generic;
using Assets.Code.Entities;
using Assets.Code.Helpers;
using UnityEngine;

public class AreaDamageEffect : MonoBehaviour
{
    public List<GameObject> EntitiesInsideTrigger;
    public float SecondsBeforeEffectStarts = 1;
    public AudioSource SpecialSfx;
    public int Damage;
    public GameObject FactionPrefab;
    public Faction Faction;

    private void Start()
    {
        EntitiesInsideTrigger = new List<GameObject>();
        StartCoroutine(ActivateEffect());
    }

    public IEnumerator ActivateEffect()
    {
        yield return new WaitForSeconds(SecondsBeforeEffectStarts);
        SpecialSfx.Play();
        EntitiesInsideTrigger.RemoveAll(x => x == null);
        foreach (var entity in EntitiesInsideTrigger)
        {
            var isNpc = entity.CompareTag(Constants.tagNpcs) ||
                        entity.transform.parent.CompareTag(Constants.tagNpcs);
            var minionComponent = entity.GetComponent<Minion>() ?? entity.GetComponentInParent<Minion>();
            var isMinion = minionComponent != null;
            var isEnemyMinion = isMinion && minionComponent.Faction != Faction;
            Debug.Log(string.Format("isNpc is {0}", isNpc.ToString()));
            Debug.Log(string.Format("isEnemyMinion is {0}", isEnemyMinion.ToString()));
            if (isNpc || isEnemyMinion)
            {
                var damageable = entity.GetComponent<Damageable>() ??
                                 entity.GetComponentInParent<Damageable>();
                if (damageable == null) Debug.Log("TODO MAL VIEJO");
                damageable.RecieveDamage(Damage, FactionPrefab);
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