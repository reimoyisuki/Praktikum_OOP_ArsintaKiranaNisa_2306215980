using UnityEngine;

public class EnemyHorizontal : Enemy
{
    public float speed = 5f;
    private Vector2 direction;

    protected override void Start()
    {
        base.Start();
        // Tentukan arah gerakan berdasarkan spawn position
        direction = transform.position.x > 0 ? Vector2.left : Vector2.right;
    }

    protected override void Update()
    {
        base.Update();
        transform.Translate(direction * speed * Time.deltaTime);

        // Jika melewati layar, ubah arah
        if (!RendererIsVisible())
        {
            direction *= -1;
        }
    }
}
