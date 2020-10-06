using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{

    [Header("Input Settings:")]
    public int playerId;
    Player player;

    [Space]
    [Header("Character Attributes:")]
    public float CROSSHAIR_DISTANCE = 2;
    public float MOVEMENT_BASE_SPEED = 3;
    public float PROJECTILE_FORCE = 20f;

    [Space]
    [Header("Character Statistics:")]
    public Vector2 movementDirection;
    public float movementSpeed;
    Vector2 mousePos;
    Vector2 firePointPos;
    public float angle;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;
    public Animator animator;
    public Transform firePoint;
    public GameObject crosshair;
    public GameObject bulletPrefab;

    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetButtonDown("Fire1"))
        {
            Fire();
        }
        ProcessInputs();
        Move();
        Animate();
        Aim();
    }

    void ProcessInputs()
    {
        movementDirection = new Vector2(player.GetAxis("Horizontal"), player.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();
    }

    void Move()
    {
        rb.velocity = (movementDirection * movementSpeed) * MOVEMENT_BASE_SPEED;
    }

    void Animate()
    {
        if (movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Movement Speed", movementSpeed);
    }

    void Fire()
    {
        Vector2 shootingDirection = crosshair.transform.localPosition;
        shootingDirection.Normalize();

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = shootingDirection * PROJECTILE_FORCE;
        bullet.transform.Rotate(0, 0, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg + 90);
        Destroy(bullet, 2.0f);
    }

    void Aim()
    {
        if (movementDirection != Vector2.zero)
        {
            //crosshair.transform.localPosition = movementDirection * CROSSHAIR_DISTANCE;
        }
    }
}
