using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayerMovement : MonoBehaviour
{
    public onWhichPlatform OnWhichPlatform;//reference to onWhichPlatform Script

    float runSpeed = 2; // for run speed
    float jumpForce = 500; //float for jump
    Animator myAnimator; //reference to attached animator

    public bool isGrounded;//bool to tell if player is grounded or not for jumping and animations
    public GameObject dialogPanel;
    public int jumpCount;//sets how many jumps the player can do
    public bool canJump;// bool that allows player to actually jump. Limits infinite jumping

    public GameObject groundCheck = null;// reference to ground check object that weare raycasting to.

    public bool isdead = false;// bool to track if I am on dead platform;
    public bool iswaving = false;// bool to track if on celebrating platform
    public bool isMoving = false;//bool to track if player is moving or not

  
    public bool canMove;//checks to see if the player can move the character at the start. if false movement keys become inactive.

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>(); //Connect reference to Object
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, groundCheck.transform.position, Color.yellow);//drawn line between center of avatar and platform

        float currentYVel = GetComponent<Rigidbody2D>().velocity.y;
        myAnimator.SetBool("isDead", isdead);//attaches isdead bool to Animator's bool
        myAnimator.SetBool("isWaving", iswaving);//attaches iswaving bool to Animator's bool
        myAnimator.SetBool("ISmoving", isMoving);//attaches isMoving bool to Animator's bool
        myAnimator.SetBool("grounded", isGrounded);//attaches Grouned bool to Animator's bool

        if (canMove == true)//if true allows player to move the character. Can be used for a pause menu as well
		{
        if (Input.GetKey(KeyCode.A))//for moving left
            {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, currentYVel);
            transform.localScale = new Vector2(-1, transform.localScale.y);
            myAnimator.SetTrigger("moving");//tells animator that player is moving
            isMoving = true;//tells animator that the player is moving
            }
        else if(Input.GetKey(KeyCode.D))//for moving right
            {
            GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, currentYVel);
            transform.localScale = new Vector2(1, transform.localScale.y);
            myAnimator.SetTrigger("moving");//tells animator that the player is moving
               isMoving = true;//tells animator that the player is moving
            }
        else//sets isMoving false whenever movement keys(A & D) are not being pressed
            {
            isMoving = false;
            }
        if (Input.GetKeyDown(KeyCode.W) && jumpCount == 0 && canJump == true)//allows jumping as long as all conditions are true
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            Debug.Log(isGrounded);
            myAnimator.SetTrigger("jump");
            jumpCount = 1; 
        }
        }
        if (jumpCount == 1)//makesm isGrounded and canJump false when mid jump. can be moddified for double jumping
		{
            isGrounded = false;
            canJump = false;
		}
        if(OnWhichPlatform.beganDialog == true)
		{
            canMove = false; 
		}
        /*if(dialogPanel.SetActive(true))
        {
            canMove = false;
        }*/

    }
    void OnCollisionEnter2D(Collision2D platform)
	{
        if(platform.gameObject.tag == "floor")//detects if the player is on a platform or not
		{
            canJump = true;
            isGrounded = true;
            isdead = false;
            jumpCount = 0; 
		}
        if(platform.gameObject.tag == "deathFloor")//detects if a player is on a death platform
		{
            canJump = true;
            isGrounded = true;
            jumpCount = 0;
            isdead = true;
            canMove = false;
        }
        if(platform.gameObject.tag == "endFloor")
        {

            canJump = true;
            isGrounded = true;
            jumpCount = 0;
            canMove = false;
        }


	}
    public void CanMove()
	{
        canMove = true;
	}
}
