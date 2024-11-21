using UnityEngine;

public class EnemyTargeting : Enemy
{
    public Transform player; // Drag Player ke sini di Inspector
    public float speed = 5f;

    protected override void Update()
    {
        base.Update();

        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); // Hapus Enemy saat bertabrakan dengan Player
        }
    }
}
