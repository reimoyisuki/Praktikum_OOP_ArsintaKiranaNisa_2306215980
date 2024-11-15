using UnityEngine;

public class EnemyForward : Enemy
{
    public float speed = 5f;

    protected override void Update()
    {
        base.Update();
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        DestroyIfOffScreen(); // Hapus jika keluar layar
    }
}
