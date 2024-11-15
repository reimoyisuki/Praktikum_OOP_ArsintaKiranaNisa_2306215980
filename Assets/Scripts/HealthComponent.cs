using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;

    private void Awake()
    {
        health = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public void Subtract(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
