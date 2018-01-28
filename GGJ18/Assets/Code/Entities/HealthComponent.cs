using UnityEngine;

public class HealthComponent : MonoBehaviour, Damageable
{
    public int HitPoints;
    public float TimeOfInmortality;
    public bool IsAlive { get{return currentHitpoints > 0;} }

    private int currentHitpoints;
    private float timerInmortality;

    public void RecieveDamage(int damage, GameObject convertTo)
    {
        currentHitpoints -= damage;
        if (currentHitpoints <= 0 && this.CompareTag(Constants.tagNpcs))
        {
            Convert(convertTo);
        }
    }

    private void Start()
    {
        timerInmortality = 0;
        FullHeal();
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
            if (HitPoints <= 0)
            {
                if (GetComponent<PlayerFactionComponent>() != null)
                {
                    GetComponent<RespawnAction>().Kill();
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
            RestartTimer();
        }
    }

    public void FullHeal()
    {
        currentHitpoints = HitPoints;
    }

    public void Convert(GameObject convertTo)
    {
        var minion = Instantiate(convertTo, transform.position, Quaternion.identity);
        minion.transform.SetParent(transform.parent);

        Destroy(this.gameObject);
    }
}