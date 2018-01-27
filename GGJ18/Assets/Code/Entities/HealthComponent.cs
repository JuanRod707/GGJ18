using UnityEngine;

public class HealthComponent : MonoBehaviour, Damageable
{
    public int HitPoints;
    public float TimeOfInmortality;

    private float timerInmortality;

    public void RecieveDamage(int damage, GameObject convertTo)
    {
        HitPoints -= damage;
        if (HitPoints <= 0 && this.CompareTag(Constants.tagNpcs))
        {
            Convert(convertTo);
        }
    }

    private void Start()
    {
        timerInmortality = 0;
    }

    void Update()
    {
        if (timerInmortality > 0)
        {
            timerInmortality -= Time.deltaTime;
        }
    }

    void RestartTimer()
    {
        timerInmortality = TimeOfInmortality;
    }

    public void RecieveDamage(int damage)
    {
        if (timerInmortality <= 0)
        {
            HitPoints -= damage;
            Debug.Log(string.Format("ReceiveDamage2::Health is currently {0}", this.HitPoints));
            if (HitPoints <= 0)
            {
                Destroy(this.gameObject);
            }
            RestartTimer();
        }
    }

    public void Convert(GameObject convertTo)
    {
        var minion = Instantiate(convertTo, transform.position, Quaternion.identity);
        minion.transform.SetParent(transform.parent);

        Destroy(this.gameObject);
    }
}