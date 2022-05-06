using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("player speed and movement")]
    public float moveSpeed = 6f;
    public Rigidbody2D rb;
    public Camera cam;
    private Vector2 moveInput;
    private Vector2 mousePos;
    public Animator animator;

    public float boostTimer;
    public bool boosting;

    // Update is called once per frame
    void Start()
    {
        boostTimer = 0;
        boosting = false;
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");

        moveInput.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", moveInput.x);
        animator.SetFloat("Speed", moveInput.y);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (boosting)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer < 0)
            {
                moveSpeed = 6f;
                boostTimer = 0;
                boosting = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerupSpeed"))        //Triggers if the player collides with object with tag "PowerupSpeed", they gain 1.5 speed multiplier.
        {
            boosting = true;
            moveSpeed = 10f;
            boostTimer = 7;
            Destroy(collision.gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 2;

        rb.rotation = angle;
    }
}