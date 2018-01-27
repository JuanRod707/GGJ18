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
        if (entityDetector.NpcsInsideTrigger.Count > 0)
        {
            foreach (var npc in entityDetector.NpcsInsideTrigger)
            {
                if (npc == null) entityDetector.NpcsInsideTrigger.Remove(npc);
                else
                {
                    npc.GetComponentInParent<Damageable>().RecieveDamage(meleeDamageComponent.Damage, FactionPrefab);
                }
            }
        }
    }
}