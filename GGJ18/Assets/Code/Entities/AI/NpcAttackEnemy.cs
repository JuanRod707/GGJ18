using Assets.Code.Entities;
using UnityEngine;
using UnityEngine.AI;

public class NpcAttackEnemy : MonoBehaviour, ReactToEnemy
{
    public float AttackRate;
    public int AttackDamage;
    public int DistanceToForget;
    public AudioSource Attacksfx;
    public GameObject ShotLinePf;
    public float ShootOffset;

    private float attackElapsed;
    private NpcRandomMovement randomMovement;
    private NavMeshAgent navAgent;
    private Transform target;

    void ReloadComponents()
    {
        if(randomMovement == null)
            randomMovement = GetComponent<NpcRandomMovement>();
        if(navAgent == null)
            navAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (target == null || Vector3.Distance(this.transform.position, target.position) > DistanceToForget)
        {
            ReloadComponents();
            randomMovement.enabled = true;
            this.enabled = false;

            randomMovement.SetNewNavPoint();
        }
        else
        {
            if (attackElapsed <= 0)
            {
                ShootTarget();
                attackElapsed = AttackRate;
            }

            attackElapsed -= Time.deltaTime;
        }
    }
    public void React(Transform fromPos)
    {
        ReloadComponents();
        target = fromPos;

        this.enabled = true;
        randomMovement.enabled = false;
    }

    void ShootTarget()
    {
        if (target != null)
        {
            target.GetComponentInParent<Damageable>().RecieveDamage(AttackDamage);
            Attacksfx.pitch = Random.Range(0.5f, 2f);
            Attacksfx.Play();

            var line = Instantiate(ShotLinePf, this.transform.position, Quaternion.identity);
            line.GetComponent<ShotLine>().DrawLine(transform.position + (Vector3.up * ShootOffset), target.position + (Vector3.up * ShootOffset));
        }
    }
}
