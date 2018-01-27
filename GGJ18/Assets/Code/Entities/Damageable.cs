using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Entities
{
    public interface Damageable
    {
        void RecieveDamage(int damage);
        void RecieveDamage(int damage, GameObject convertTo);
    }
}
