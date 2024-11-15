using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;

    private Rigidbody2D rb;
    private IObjectPool<Bullet> bulletPool;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
    }

    public void SetPool(IObjectPool<Bullet> pool)
    {
        bulletPool = pool;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Obstacle"))
        {
            bulletPool.Release(this); // Kembalikan Bullet ke Pool
        }
    }

    void OnBecameInvisible()
    {
        // Jika Bullet keluar layar, kembalikan ke Pool
        bulletPool.Release(this);
    }
}
