using Assets.Code.Helpers;
using UnityEngine;

namespace Assets.Code.Entities
{
    public class Minion : MonoBehaviour, Damageable
    {
        public Faction Faction;

        public int HitPoints;
        public int DamagePerHit;
        public float AttackRate;

        public string ConvertToId;
        public string RefName;

        public string DirectorName;

        public AudioSource PunchSfx;

        private float attackElapsed;
        private PrefabReferences refs;

        private Director director;

        void Start()
        {
            refs = GameObject.Find(RefName).GetComponent<PrefabReferences>();
            var directorGo = GameObject.Find(DirectorName);
            if(directorGo != null)
            {
                director = directorGo.GetComponent<Director>();
                director.AddScore(this.Faction);
            }
        }

        public void RecieveDamage(int damage, GameObject convertTo)
        {
            RecieveDamage(damage);
        }

        public void RecieveDamage(int damage)
        {
            HitPoints -= damage;
            if (HitPoints <= 0)
            {
                if(director != null)
                    director.SubstractScore(Faction);
                Destroy(this.gameObject);
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.other.CompareTag("Npcs"))
            {
                if (attackElapsed <= 0)
                {
                    collision.other.GetComponent<HealthComponent>()
                        .RecieveDamage(DamagePerHit, refs.GetMinionById(ConvertToId));
                    attackElapsed = AttackRate;
                    PunchSfx.Play();
                }
                else
                {
                    attackElapsed -= Time.deltaTime;
                }
            }
            else if (collision.other.CompareTag("Minion"))
            {
                var minion = collision.other.GetComponent<Minion>();
                if (minion.Faction != this.Faction)
                {
                    if (attackElapsed <= 0)
                    {
                        collision.other.GetComponent<Minion>()
                            .RecieveDamage(DamagePerHit);
                        attackElapsed = AttackRate;
                        PunchSfx.Play();
                    }
                    else
                    {
                        attackElapsed -= Time.deltaTime;
                    }
                }
            }
        }
    }
}