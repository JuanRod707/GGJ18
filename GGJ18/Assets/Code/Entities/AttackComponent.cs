using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public GameObject FactionPrefab;
    public AudioSource AttackSfx;

    private EntityDetector entityDetector;
    private MeleeDamageComponent meleeDamageComponent;
    
    private void Start()
    {
        entityDetector = GetComponentInChildren<EntityDetector>();
        meleeDamageComponent = GetComponent<MeleeDamageComponent>();
    }

    public void AttemptAttack()
    {
        HitEnemiesWithinTrigger();
    }

    private void HitEnemiesWithinTrigger()
    {
        entityDetector.EntitiesInsideTrigger.RemoveAll(x => x == null);
        if (entityDetector.EntitiesInsideTrigger.Count > 0)
        {
            foreach (var entity in entityDetector.EntitiesInsideTrigger)
            {
                var damageableComponent = entity.GetComponentInParent<Damageable>() ?? entity.GetComponent<Damageable>();
                if (damageableComponent != null)
                {
                    if (entity.CompareTag(Constants.tagPlayer))
                    {
                        damageableComponent.RecieveDamage(meleeDamageComponent.Damage);
                    }
                    else
                    {
                        damageableComponent.RecieveDamage(meleeDamageComponent.Damage, FactionPrefab);
                    }
                }
            }

            AttackSfx.Play();
        }
    }
}