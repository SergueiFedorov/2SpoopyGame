﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		
	}

	Vector2 raycastDirection = new Vector2(0.0f, -1.0f);

	float jumpForce = 200.0f;

	// Update is called once per frame
	void Update () {


		RaycastHit2D raycastHit = default(RaycastHit2D);

		raycastHit = Physics2D.Raycast ((Vector2)this.transform.position - (Vector2.up * this.collider2D.bounds.size.y * 0.55f), raycastDirection, 0.05f);
		if (raycastHit.collider != null) 
		{
			//Debug.Log(raycastHit.collider.tag);
			if (Input.GetButtonDown ("JUMP"))
			{
				this.rigidbody2D.AddForce(Vector2.up * jumpForce);
			}
		}

		if (rigidbody2D.velocity.x < 10.0f && rigidbody2D.velocity.x > -10.0f)
		{
			rigidbody2D.AddForce(Vector2.right * Input.GetAxisRaw ("Move_X") * 10);
			anim.SetFloat("speed", Mathf.Abs(rigidbody2D.velocity.x));
		}

		Debug.DrawRay ((Vector2)this.transform.position - (Vector2.up * this.collider2D.bounds.size.y * 0.5f), raycastDirection * 0.05f, Color.red);

		Physics2D.IgnoreLayerCollision(this.gameObject.layer, LayerMask.NameToLayer("platform"), rigidbody2D.velocity.y > 0.0f);

	}

	void OnCollisionExit2D(Collision2D collision) 
	{

	}

	void OnCollisionEnter2D(Collision2D collision)
	{

	}
}
