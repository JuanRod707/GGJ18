using Assets.Code.Helpers;
using UnityEngine;

public class SpecialComponent : MonoBehaviour
{
    public GameObject robotAreaDamageEffectPrefab;
    public float SecondsBetweenSpecials = 2.0f;
    private float timeSinceLastSpecial;
    public Faction Faction;

    private void Update()
    {
        timeSinceLastSpecial += Time.deltaTime;
//        Debug.Log(string.Format("Time since last special is {0}", timeSinceLastSpecial));
    }

    public void AttemptSpecial()
    {
        if (timeSinceLastSpecial > SecondsBetweenSpecials)
        {
            timeSinceLastSpecial = 0.0f;
            if (Faction == Faction.Robot)
            {
                Instantiate(robotAreaDamageEffectPrefab, this.transform.position, Quaternion.identity);
            }
        }
    }
}