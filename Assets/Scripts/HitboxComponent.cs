using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent health;

    public void Damage(Bullet bullet)
    {
        Damage(bullet.GetDamage());
    }

    public void Damage(int damage)
{
    InvincibilityComponent invincibility = GetComponent<InvincibilityComponent>();
    if (invincibility != null && invincibility.isInvincible)
    {
        return;
    }

    if (health != null)
    {
        health.Subtract(damage);
    }
}

}
