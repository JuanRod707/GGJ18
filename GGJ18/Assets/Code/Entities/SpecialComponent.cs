using UnityEngine;

public class SpecialComponent : MonoBehaviour
{
    private AreaDamageEffect areaDamageEffect;
    public float SecondsBetweenSpecials = 2.0f;
    private float timeSinceLastSpecial;
    public AudioSource SpecialSfx;

    void Start()
    {
        areaDamageEffect = GetComponentInChildren<AreaDamageEffect>();
    }

    private void Update()
    {
        timeSinceLastSpecial += Time.deltaTime;
        Debug.Log(string.Format("Time since last special is {0}", timeSinceLastSpecial));
    }

    public void AttemptSpecial()
    {
        if (areaDamageEffect != null)
        {
            if (timeSinceLastSpecial > SecondsBetweenSpecials)
            {
                timeSinceLastSpecial = 0.0f;

                areaDamageEffect.ActivateEffect();
                SpecialSfx.Play();
            }
        }
    }
}