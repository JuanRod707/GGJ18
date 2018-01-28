using System;
using Assets.Code.Helpers;
using UnityEngine;

public class SpecialComponent : MonoBehaviour
{
    public GameObject areaDamageEffectPrefab;
    public float SecondsBetweenSpecials = 4.0f;
    private float timeSinceLastSpecial;
    public Faction Faction;

    private void Start()
    {
        timeSinceLastSpecial = SecondsBetweenSpecials;
    }

    private void Update()
    {
        timeSinceLastSpecial += Time.deltaTime;
//        Debug.Log(string.Format("Time since last special is {0}", timeSinceLastSpecial));
    }

    public void AttemptSpecial()
    {
        if (timeSinceLastSpecial >= SecondsBetweenSpecials)
        {
            timeSinceLastSpecial = 0.0f;
            Instantiate(areaDamageEffectPrefab, this.transform.position, Quaternion.identity);
        }
    }
}