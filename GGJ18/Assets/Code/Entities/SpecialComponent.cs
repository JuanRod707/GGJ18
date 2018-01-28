using UnityEngine;

public class SpecialComponent : MonoBehaviour
{
    public GameObject areaDamageEffect;
    public float SecondsBetweenSpecials = 2.0f;
    private float timeSinceLastSpecial;

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
            Instantiate(areaDamageEffect, this.transform.position, Quaternion.identity);
        }
    }
}