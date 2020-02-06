using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePEn : MonoBehaviour
{
float runSpeed = 2; // for run speed
float jumpForce = 300; //float for jump
Animator myAnimator; //reference to attached animator 
public bool grounded = false; //bool for tracking grounded

public GameObject groundCheck = null;// reference to ground check object that weare raycasting to.
public bool isdead = false;// bool to track if I am on dead platform;
public bool iswaving = false;// bool to track if on celebrating platform
public bool isMoving = true;


	// Use this for initialization
	void Start () 
    {
myAnimator = GetComponent<Animator>(); //Connect reference to Object
	}
	
	// Update is called once per frame
	void Update () {
    Debug.DrawLine(transform.position, groundCheck.transform.position, Color.yellow);//drawn line between center of avatar and platform
    
		float currentYVel = GetComponent<Rigidbody2D> ().velocity.y; 
    if(Physics2D.Linecast(transform.position, groundCheck.transform.position))
        {
        grounded = true;
        RaycastHit2D hitPlatform = Physics2D.Linecast(transform.position, groundCheck.transform.position);
        if(hitPlatform != null && hitPlatform.collider.name == "DeathPlatform")//detects death platform
            {
            isdead = true;//bool being sent to animator 
            }
        if(hitPlatform != null && hitPlatform.collider.name == "WavePlatform")//detects waving platform
            {
            iswaving = true;//bool being sent to animator
            }
        }
    else
    {
    grounded = false;
    isdead = false;
    iswaving = false;
    isMoving = true;
    }//if not hittin any platform all bools are set to false
        
    myAnimator.SetBool("isDead", isdead);
    myAnimator.SetBool("isWaving", iswaving);
    myAnimator.SetBool("isNotMoving",isMoving);
    
    
    
		if (Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-runSpeed, currentYVel);
			transform.localScale = new Vector2 (-1, transform.localScale.y);
            myAnimator.SetTrigger("moving");
            isMoving = false;
            }
 else if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (runSpeed, currentYVel);
			transform.localScale = new Vector2 (1, transform.localScale.y);
            myAnimator.SetTrigger("moving");
            isMoving = false;
				}
            if (Input.GetKeyDown (KeyCode.UpArrow)) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
			Debug.Log (grounded);
            myAnimator.SetTrigger("jump");
                }

		}

			
}