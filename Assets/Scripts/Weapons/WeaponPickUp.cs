using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder;
    private Weapon weapon;

    private void Awake()
    {
        // Buat instance dari weaponHolder dan simpan di weapon
        if (weaponHolder != null)
        {
            weapon = Instantiate(weaponHolder);
        }
    }

    void Start()
    {
        if (weapon != null)
        {
            TurnVisual(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player picked up weapon");

            // Cek apakah player sudah memiliki weapon
            Weapon currentWeapon = collision.gameObject.GetComponentInChildren<Weapon>();
            if (currentWeapon != null)
            {
                Destroy(currentWeapon.gameObject); // Hapus weapon yang ada jika sudah ada sebelumnya
            }

            if (weapon != null)
            {
                weapon.transform.SetParent(collision.gameObject.transform, false);
                TurnVisual(true);
            }
            else
            {
                Debug.LogWarning("Weapon is null!");
            }
        }
    }

    private void TurnVisual(bool on)
    {
        // Pastikan weapon tidak null sebelum mengubah visualnya
        if (weapon != null)
        {
            TurnVisual(on, weapon);
        }
    }

    private void TurnVisual(bool on, Weapon weapon)
    {
        if (weapon != null)
        {
            // Aktifkan atau nonaktifkan komponen visual dari weapon
            var spriteRenderer = weapon.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = on;
            }

            var animator = weapon.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = on;
            }

            weapon.enabled = on;
        }
    }
}
