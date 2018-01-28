using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour, Damageable
{
    public int HitPoints;
    public float TimeOfInmortality;
    public bool IsAlive { get{return currentHitpoints > 0;} }
    public Image HpBar;

    public int currentHitpoints;
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
            currentHitpoints -= damage;
            if (HpBar != null)
            {
                UpdateHpBar();
            }

        if (currentHitpoints <= 0)
            {
                var playerComp = GetComponent<PlayerFactionComponent>();
                if (playerComp != null)
                {
                    GameObject.Find("NPCs").GetComponent<DestroyMyMinions>()
                        .DestroyMinions(playerComp.PlayerFaction, playerComp.DeathPenalty);
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

    private void UpdateHpBar()
    {
        HpBar.fillAmount = (float) currentHitpoints / (float)HitPoints;
    }

    public void FullHeal()
    {
        currentHitpoints = HitPoints;
        if (HpBar != null)
        {
            UpdateHpBar();
        }
    }

    public void Convert(GameObject convertTo)
    {
        var minion = Instantiate(convertTo, transform.position, Quaternion.identity);
        minion.transform.SetParent(transform.parent);

        Destroy(this.gameObject);
    }
}