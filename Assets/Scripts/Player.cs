using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
// Singleton Instance
    public static Player Instance { get; private set; }

    public PlayerMovement playerMovement;
    private Animator animator;

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Mengambil komponen dari GameObject lain
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Memanggil method Move dari PlayerMovement
        playerMovement.Move();
    }

    void LateUpdate()
    {
        // Mengatur nilai Bool dari parameter IsMoving di Animator
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }
}
