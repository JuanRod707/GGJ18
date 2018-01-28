using System.Collections;
using System.Collections.Generic;
using Assets.Code.Entities;
using Assets.Code.Helpers;
using UnityEngine;

public class AreaDamageEffect : MonoBehaviour
{
    public List<GameObject> EntitiesInsideTrigger;
    public float SecondsBeforeEffectStarts;
    public AudioSource SpecialSfx;
    public List<GameObject> ParticleEffects;
    public float ParticleEffectDurationInSeconds;
    public float EffectDuration;
    public int Damage;
    public GameObject FactionPrefab;
    public Faction Faction;

    private List<Damageable> damageables;

    private void Start()
    {
        damageables = new List<Damageable>();
        EntitiesInsideTrigger = new List<GameObject>();
        StartCoroutine(ActivateEffect());
    }

    public IEnumerator ActivateEffect()
    {
        yield return new WaitForSeconds(SecondsBeforeEffectStarts);
        SpecialSfx.Play();
        GenerateParticleEffects();
        EntitiesInsideTrigger.RemoveAll(x => x == null);
        foreach (var entity in EntitiesInsideTrigger)
        {
            var isNpc = entity.CompareTag(Constants.tagNpcs) ||
                        entity.transform.parent.CompareTag(Constants.tagNpcs);
            var isEnemyMinion = IsEntityEnemyMinion(entity);
            if (isNpc || isEnemyMinion)
            {
                InflictDamageOnEntity(entity);
            }
        }

        damageables.Clear();
        EntitiesInsideTrigger.Clear();
        yield return new WaitForSeconds(EffectDuration);
        Destroy(this.gameObject);
    }

    private void GenerateParticleEffects()
    {
        foreach (var particleEffect in ParticleEffects)
        {
            var newParticleEffect = Instantiate(particleEffect, this.transform.position, Quaternion.identity);
            StartCoroutine(DestructParticleEffectsSystem(newParticleEffect));
        }
    }

    private IEnumerator DestructParticleEffectsSystem(GameObject particleEffects)
    {
        yield return new WaitForSeconds(ParticleEffectDurationInSeconds);
        Destroy(particleEffects);
    }

    private bool IsEntityEnemyMinion(GameObject entity)
    {
        var minionComponent = entity.GetComponent<Minion>() ?? entity.GetComponentInParent<Minion>();
        var isMinion = minionComponent != null;
        var isEnemyMinion = isMinion && minionComponent.Faction != Faction;
        return isEnemyMinion;
    }

    private void InflictDamageOnEntity(GameObject entity)
    {
        var damageable = entity.GetComponent<Damageable>() ??
                         entity.GetComponentInParent<Damageable>();
        if (!damageables.Contains(damageable))
        {
            damageable.RecieveDamage(Damage, FactionPrefab);
            damageables.Add(damageable);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!EntitiesInsideTrigger.Contains(other.gameObject))
        {
            EntitiesInsideTrigger.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EntitiesInsideTrigger.Remove(other.gameObject);
    }
}