using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private float speed;       // Kecepatan gerak Portal
    [SerializeField] private float rotateSpeed; // Kecepatan putar Portal
    private Vector2 newPosition;               // Posisi baru yang akan dituju oleh Portal

    private void Start()
    {
        ChangePosition(); // Inisialisasi posisi awal dari Portal
    }

    private void Update()
    {
        // Menggerakkan portal menuju posisi baru
        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);

        // Memutar portal
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        // Cek apakah posisi portal mendekati newPosition, jika iya maka buat posisi baru
        if (Vector2.Distance(transform.position, newPosition) < 0.5f)
        {
            ChangePosition();
        }

        // Cek apakah player memiliki weapon
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Weapon weapon = player.GetComponentInChildren<Weapon>();
            if (weapon == null)
            {
                
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Collider2D>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.LevelManager.LoadScene("Main");
        }
    }

    
    private void ChangePosition()
    {
        float x = Random.Range(-10f, 10f); 
        float y = Random.Range(-10f, 10f); 
        newPosition = new Vector2(x, y);
    }
}
