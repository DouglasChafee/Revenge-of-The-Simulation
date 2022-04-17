using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private float speed;
    public float speedValue;
    public float jumpSpeed;
    private float moveInput;
    public Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Animator animator;

    private int extraJumps;  // Number of jumps
    public int extraJumpsValue;
    private bool tripleJump = false;

    // Use this for initialization
    void Start() {
        extraJumps = extraJumpsValue;
        speed = speedValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (tripleJump == true)
        {
            extraJumpsValue += 1;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = speedValue / 2;
            Debug.Log("Shift Pressed");

        }
        else {
            speed = speedValue;
        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            animator.SetBool("isJumping", true);
            FindObjectOfType<AudioManager>().Play("Jump");
            extraJumps--;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            animator.SetBool("isJumping", true);
        }
    }

    // Manage physics related aspects of the game
    void FixedUpdate() {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        //Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }

        if (facingRight == false && moveInput > 0) {
            Flip();
        } else if(facingRight == true && moveInput < 0) {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
