using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public PlayerMovement playerMovement;
    private Animator animator;

    private float leftLimit;
    private float rightLimit;
    private float topLimit;
    private float bottomLimit;

    private Camera mainCamera;

    void Awake()
    {
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
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();

        // Set camera bounds
        mainCamera = Camera.main;
        Vector3 screenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.z));
        rightLimit = screenBounds.x;
        leftLimit = -screenBounds.x;
        topLimit = screenBounds.y;
        bottomLimit = -screenBounds.y;
    }

    void FixedUpdate()
    {
        playerMovement.Move();
        ClampPosition();
        MoveBound(); // Tambahkan panggilan MoveBound() di sini
    }

    void LateUpdate()
    {
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }

    private void ClampPosition()
    {
        Vector3 clampedPosition = transform.position;
        
        // Clamp the position within screen bounds
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftLimit, rightLimit);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, bottomLimit, topLimit);
        
        // Set the clamped position back to the transform
        transform.position = clampedPosition;
    }

    public void MoveBound()
    {
        if (mainCamera == null) return;
        Vector2 min = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        
        transform.position = new Vector2
        (
            Mathf.Clamp(transform.position.x, min.x + (transform.localScale.x / 2), max.x - (transform.localScale.x / 2)),
            Mathf.Clamp(transform.position.y, min.y + (transform.localScale.y / 10), max.y - (transform.localScale.y / 1.5f))
        );
    }
}
