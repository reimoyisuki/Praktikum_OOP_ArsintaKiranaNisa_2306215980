using UnityEngine;

public class EnemyBoss : Enemy
{
    public Transform bulletSpawnPoint;
    public Bullet bulletPrefab;
    public float shootInterval = 2f;
    private float timer;

    public float speed = 2f;

    protected override void Start()
    {
        base.Start();
        timer = shootInterval;
    }

    protected override void Update()
    {
        base.Update();

        // Enemy bergerak sedikit (contoh: kiri-kanan)
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (!RendererIsVisible())
        {
            speed *= -1; // Balik arah jika keluar layar
        }

        // Tembak peluru
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Shoot();
            timer = shootInterval;
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }
}
