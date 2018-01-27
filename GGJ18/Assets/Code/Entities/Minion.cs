using UnityEngine;

namespace Assets.Code.Entities
{
    public class Minion : MonoBehaviour, Damageable
    {
        public int HitPoints;
        public int DamagePerHit;
        public string ConvertToId;
        public string RefName;

        private PrefabReferences refs;

        void Start()
        {
            refs = GameObject.Find(RefName).GetComponent<PrefabReferences>();
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
                Destroy(this.gameObject);
            }
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.CompareTag("Npcs"))
        //    {
        //        other.GetComponentInParent<Npc>().RecieveDamage(DamagePerHit, refs.GetMinionById(ConvertToId));
        //    }
        //}
        
        private void OnCollisionStay(Collision collision)
        {
            if (collision.other.CompareTag("Npcs"))
            {
                collision.other.GetComponent<Npc>().RecieveDamage(DamagePerHit, refs.GetMinionById(ConvertToId));
            }
        }
    }
}
