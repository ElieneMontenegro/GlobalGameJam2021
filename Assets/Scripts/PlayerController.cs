using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;


public class PlayerController : MonoBehaviour
{

    //running
    public float speed;
    private bool facingRight = true;
    private Vector3 scale;

    //jumping
    public float jumpForce;
    //fixing the jump bug
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private Animator anim;

    private Rigidbody2D rigidBody;

    //climbable Stuff
    bool onClimbable = false;
    bool isClimbing = false;
    private bool canClimb;
    float climbPercentage;
    float ClimbingSpeed = 1f;
    Vector2 vectorStart, vectorEnd; //Starting and Ending Point of the Climbable

    //pontos
    public int pontos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        IsJumping();
        Climb();
        Win();
    }

    void Move()
    {
        if(Input.GetAxis("Horizontal") > 0)
        {
            if(!facingRight)
            {
                Flip();
            }
            anim.SetBool("isRunning", true);

            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * speed;
        }
       else if (Input.GetAxis("Horizontal") < 0)
        {
            if (facingRight)
            {
                Flip();
            }
            anim.SetBool("isRunning", true);

            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            transform.position += movement * Time.deltaTime * speed;
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

    }

    void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Jump()
    {
        CheckSurroundings();

        if(Input.GetButtonDown("Jump") && isGrounded)
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    void IsJumping()
    {
        if (!isGrounded)
        {
            anim.SetBool("isJumping", true);
        } else
        {
            anim.SetBool("isJumping", false);
        }
    }

    void Climb()
    {
        if (onClimbable || isClimbing) //Check if the Player is on a Climbable or Climbing one
            UseClimbable();
    }

    void UseClimbable()
    {
        float inputVer = Input.GetAxisRaw("Vertical");

        if (inputVer != 0)
        {
            //Climb base on the percentage so we could back and forward based on the inputVer
            climbPercentage += Time.deltaTime * ClimbingSpeed * inputVer;
            this.gameObject.transform.position = Vector2.Lerp(vectorStart, vectorEnd, climbPercentage);
        }

        climbPercentage = Mathf.Clamp01(climbPercentage);

        //if the Player reaches any end he can move again
        if (climbPercentage == 0 || climbPercentage == 1)
        {
            isClimbing = false;
            canClimb = true;
        }
        else
        {
            isClimbing = true;
            canClimb = false;
        }
    }

    //set the Climbable Data
    public void SetClimbableData(bool onClimbable, Vector2 StartY, Vector2 EndY, bool isDown, float ClimbingSpeed)
    {
        this.onClimbable = onClimbable;

        this.vectorStart = StartY;
        this.vectorEnd = EndY;

        //to Check at what end the Player is
        if (isDown)
            climbPercentage = 0;
        else
            climbPercentage = 1;

        this.ClimbingSpeed = ClimbingSpeed;
    }
    public void OffClimbable()
    {
        onClimbable = false;
    }

    public void Win()
    {
        if(pontos == 2)
        {
            SceneManager.LoadScene(2);
        }
    }
}
