using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Code.Entities
{
    public interface ReactToEnemy
    {
        void React(Transform fromPos);
    }
}
