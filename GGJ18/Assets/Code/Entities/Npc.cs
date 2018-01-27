using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Entities
{
    public class Npc : MonoBehaviour, Damageable
    {
        public int HitPoints;

        public void RecieveDamage(int damage, GameObject convertTo)
        {
            HitPoints -= damage;
            if (HitPoints <= 0)
            {
                Convert(convertTo);
            }
        }

        public void RecieveDamage(int damage)
        {
            HitPoints -= damage;
            if (HitPoints <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        public void Convert(GameObject convertTo)
        {
            var minion = Instantiate(convertTo, transform.position, Quaternion.identity);
            minion.transform.SetParent(transform.parent);

            Destroy(this.gameObject);
        }
    }
}
