using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

   public float getX=0;
   public bool Jumping;
    [SerializeField] private float xspeed=7f;
    [SerializeField] private float jump=14f;
    [SerializeField] private LayerMask jumpableGround;


    private enum MovementState {idle, running, jumping, falling}

    //sound variable

    [SerializeField] private AudioSource jumpsound;

    // Start is called before the first frame update
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sprite = GetComponent<SpriteRenderer>();
		coll = GetComponent<BoxCollider2D>();
		Jumping = false;

    }

    public void MoveLeft()
    {
    	getX= -1;
	}
	public void MoveRight()
	{
		getX=1;
	}

	public void JumpMovement()
	{
		Jumping= true;
	}

	public void StopMovement()
	{
		getX=0;
		Jumping= false;
	}





    // Update is called once per frame
    private void Update()
    {


	//getX= Input.GetAxisRaw("Horizontal");
	rb2d.velocity = new Vector2(getX*xspeed, rb2d.velocity.y);



    if(Jumping /*Input.GetButtonDown("Jump")*/  && IsGrounded())
	{
		jumpsound.Play();
	   rb2d.velocity = new Vector2(rb2d.velocity.x,jump);
	}


	Animatorfrog();

    }

	private void Animatorfrog()
	{
		MovementState state;

		if(getX >0f)        // right running
		{
			state = MovementState.running;
			sprite.flipX= false;
		}
		else if(getX <0f)       //left running
		{
			state = MovementState.running;
			sprite.flipX=true;
		}
		else
		{
			state = MovementState.idle;  // resting
		}

		if(rb2d.velocity.y> 0.01f)     //jumping
		{
			state = MovementState.jumping;
		}
		else if(rb2d.velocity.y< -0.01f)
		{
			state = MovementState.falling;
		}

		anim.SetInteger("state",(int)state);
	}

	private bool IsGrounded()
	{
		return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
	}



}
