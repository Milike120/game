using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    public Animator animator;
    public float moveSpeed;
    float move;
    public GameObject hero;
    private Vector3 turnRight, turnLeft;

    private void Start() {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        hero = GameObject.Find("Hero");

        turnLeft = new Vector3(-1, 1, 1);
        turnRight = new Vector3(1, 1, 1);
    }

    private void Update()
    {
        //Running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 5f;
        }
        else
        {
            moveSpeed = 3f;
        }

        //Attack
        if (Input.GetKey(KeyCode.F))
        {
            GetComponent<Animator>().SetTrigger("axe");
            animator.SetBool("ButtonPressed", true);
        } else
        {
            animator.SetBool("ButtonPressed", false);
        }

        //Jump
        if (IsGrounded() && Input.GetButtonDown("Jump")) {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
    }

    private void FixedUpdate()
    {
        //Handle Movement
        if (Input.GetKey(KeyCode.A)) {
            rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            animator.SetFloat("Speed", moveSpeed);
            hero.transform.localScale = turnLeft;
            GetComponent<Animator>().Play("HeroRun");
        } else {
            if (Input.GetKey(KeyCode.D)) {
                rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
                animator.SetFloat("Speed", moveSpeed);
                hero.transform.localScale = turnRight;
                GetComponent<Animator>().Play("HeroRun");
            } else {
                //No keys pressed
                rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
                animator.SetFloat("Speed", 0);
                GetComponent<Animator>().Play("Idle");
            }
        }
    }

    private bool IsGrounded()
    {
        float extraHeightText = .3f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeightText, platformLayerMask);
        Color rayColor;
        if (raycastHit.collider != null) {
            rayColor = Color.green;
        } else {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider2d.bounds.center, Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText), rayColor);
        return raycastHit.collider != null;
    }
}
