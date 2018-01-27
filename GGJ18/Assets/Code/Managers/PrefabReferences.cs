using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Code.Helpers;
using UnityEngine;

public class PrefabReferences : MonoBehaviour
{
    public PrefabIdPair[] Minions;
    public PrefabIdPair[] Npcs;

    public GameObject GetMinionById(string id)
    {
        return Minions.First(x => x.PfId.Equals(id)).Prefab;
    }
    public GameObject GetNpcById(string id)
    {
        return Npcs.First(x => x.PfId.Equals(id)).Prefab;
    }
}
