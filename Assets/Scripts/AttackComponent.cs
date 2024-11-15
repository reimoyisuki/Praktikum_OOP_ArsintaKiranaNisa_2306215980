using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag(gameObject.tag))
    {
        return;
    }

    HitboxComponent hitbox = collision.GetComponent<HitboxComponent>();
    InvincibilityComponent invincibility = collision.GetComponent<InvincibilityComponent>();

    if (hitbox != null)
    {
        if (invincibility != null && !invincibility.isInvincible)
        {
            invincibility.StartInvincibility();
            hitbox.Damage(damage);
        }
        else if (invincibility == null)
        {
            hitbox.Damage(damage);
        }
    }
}

}
