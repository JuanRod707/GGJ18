using Assets.Code.Helpers;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public float InitTimeToGenerate;
    public float MaxTimeGenerate;
    public float MinTimeGenerate;
    public string[] canBeSpawned;
    public string RefName;
    public string NpcParentName;

    private PrefabReferences refs;
    private Transform npcParent;
    private float timerElapsed;

    void Start()
    {
        refs = GameObject.Find(RefName).GetComponent<PrefabReferences>();
        npcParent = GameObject.Find(NpcParentName).transform;
        RestartTimer();
    }

    void Update()
    {
        if(InitTimeToGenerate < 0)
        {
            timerElapsed -= Time.deltaTime;
            if (timerElapsed < 0)
            {
                RestartTimer();
                SpawnNpc();
            }
        }
        else
        {
            InitTimeToGenerate -= Time.deltaTime;
        }
    }

    private void RestartTimer()
    {
        timerElapsed = Random.Range(MinTimeGenerate, MaxTimeGenerate);
    }
    private void SpawnNpc()
    {
        var spawned = Instantiate(refs.GetNpcById(canBeSpawned.PickOne()), transform.position, Quaternion.identity);
        spawned.transform.SetParent(npcParent);
    }
}
