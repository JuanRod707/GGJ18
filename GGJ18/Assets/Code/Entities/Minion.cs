using System.Linq;
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
        public string[] TagsToDamage;

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
            if (TagsToDamage.Contains(collision.other.tag))
            {
                if (attackElapsed <= 0)
                {
                    var player = collision.other.GetComponent<PlayerFactionComponent>();
                    var minion = collision.other.GetComponent<Minion>();

                    if ((minion != null && minion.Faction != Faction) || (player != null && player.PlayerFaction != Faction))
                    {
                        collision.other.GetComponent<Damageable>()
                            .RecieveDamage(DamagePerHit);
                        attackElapsed = AttackRate;
                        PunchSfx.Play();
                    }
                    else
                    {
                        collision.other.GetComponent<Damageable>()
                            .RecieveDamage(DamagePerHit, refs.GetMinionById(ConvertToId));
                        attackElapsed = AttackRate;
                        PunchSfx.Play();
                    }
                }
                else
                {
                    attackElapsed -= Time.deltaTime;
                }
            }
        }
    }
}