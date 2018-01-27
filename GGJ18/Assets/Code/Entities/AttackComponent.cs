using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    private EntityDetector entityDetector;
    private MeleeDamageComponent meleeDamageComponent;
    public GameObject FactionPrefab;

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
                var damageableComponent =
                    entity.GetComponentInParent<Damageable>() ?? entity.GetComponent<Damageable>();
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
    }
}