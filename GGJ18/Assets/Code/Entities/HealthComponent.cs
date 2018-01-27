using UnityEngine;

public class HealthComponent : MonoBehaviour, Damageable
{
    public int HitPoints;

    public void RecieveDamage(int damage, GameObject convertTo)
    {
        HitPoints -= damage;
        if (HitPoints <= 0 && this.CompareTag(Constants.tagNpcs))
        {
            Convert(convertTo);
        }
    }

    public void RecieveDamage(int damage)
    {
        HitPoints -= damage;
        Debug.Log(string.Format("ReceiveDamage2::Health is currently {0}", this.HitPoints));
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