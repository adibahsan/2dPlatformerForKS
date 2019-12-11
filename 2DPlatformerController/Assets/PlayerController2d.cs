using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController2d : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;
	public Rigidbody2D rigidbody2D;
	public Animator animator;

	public bool isGrounded =false;

	public Transform groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		animator.SetFloat("runSpeed", Math.Abs(rigidbody2D.velocity.x));
		if (isGrounded)
		{
			animator.SetBool("isJumping", false);

		}

		else animator.SetBool("isJumping", true);

		if (Input.GetButton("Fire1"))
		{
			animator.Play("shoot");
		}
	}

	 void FixedUpdate()
	{
		//if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
		//{
		//	isGrounded = true;
		//}
		//else isGrounded = false;

		if(Input.GetKey("d") || Input.GetKey("right"))
		{
			rigidbody2D.velocity = new Vector2(2, rigidbody2D.velocity.y);
			spriteRenderer.flipX = false;
			//if (isGrounded)
			//	animator.Play("Run");
		}

		else if (Input.GetKey("a") || Input.GetKey("left"))
		{
			rigidbody2D.velocity = new Vector2(-2, rigidbody2D.velocity.y);
			spriteRenderer.flipX = true;
			//if (isGrounded)
			//	animator.Play("Run");
		}

		else
		{
			rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
			//if (isGrounded)
			//	animator.Play("Idle");
		}

		 if (Input.GetKey("space") && isGrounded)
		{
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 3.5f);
			//animator.Play("Jump");
		}
		

	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "platform")
		{
			isGrounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.tag == "platform")
		{
			isGrounded = false;
		}
	}
}
