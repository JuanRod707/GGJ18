using UnityEngine;

public interface Damageable
{
    void RecieveDamage(int damage);
    void RecieveDamage(int damage, GameObject convertTo);
}