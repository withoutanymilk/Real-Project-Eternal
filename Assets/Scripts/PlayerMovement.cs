using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("player speed and movement")]
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    private Vector2 moveInput;
    private Vector2 mousePos;
    public Animator animator;


    // Update is called once per frame
    void Start()
    {

    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
              
        moveInput.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", moveInput.x);
        animator.SetFloat("Speed", moveInput.y);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }
       
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 2;

       rb.rotation = angle;
    }
}