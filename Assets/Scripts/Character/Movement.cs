using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
	Animator anim;

	void Start () {

		anim = GetComponent<Animator> ();

	}

	Vector2 raycastDirection = new Vector2(0.0f, -1.0f);

	float jumpForce = 400.0f;

	int dropTimer = 0;

	// Update is called once per frame
	void FixedUpdate () {

		dropTimer--;

		RaycastHit2D raycastHit = default(RaycastHit2D);

		raycastHit = Physics2D.Raycast ((Vector2)this.transform.position - (Vector2.up * this.collider2D.bounds.size.y * 0.55f), raycastDirection, 0.05f);
		if (raycastHit.collider != null) 
		{
			//Debug.Log(raycastHit.collider.tag);
			if (Input.GetButtonDown ("JUMP") || Input.GetKeyDown(KeyCode.UpArrow))
			{
				Physics2D.IgnoreLayerCollision( this.gameObject.layer, LayerMask.NameToLayer("platform"), true);
				this.rigidbody2D.AddForce(Vector2.up * jumpForce); 
			}
		}

		if (rigidbody2D.velocity.x < 10.0f && rigidbody2D.velocity.x > -10.0f)
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				rigidbody2D.AddForce(Vector2.right * -10.0f);
			}

			if (Input.GetKey(KeyCode.RightArrow))
			{
				rigidbody2D.AddForce(Vector2.right * 10.0f);
			}

			rigidbody2D.AddForce(Vector2.right * Input.GetAxisRaw ("Move_X") * 10);
		}

		if (Input.GetButtonDown ("DROP"))
		{
			Physics2D.IgnoreLayerCollision( this.gameObject.layer, LayerMask.NameToLayer("platform"), true);
			dropTimer = 20;

		}

		Debug.Log (dropTimer);

		anim.SetFloat ("speed", Mathf.Abs(rigidbody2D.velocity.x));
		Debug.DrawRay ((Vector2)this.transform.position - (Vector2.up * this.collider2D.bounds.size.y * 0.5f), raycastDirection * 0.05f, Color.red);

		if (dropTimer < 0)
		{
			Physics2D.IgnoreLayerCollision(this.gameObject.layer, LayerMask.NameToLayer("platform"), rigidbody2D.velocity.y > 0.0f);
		}
	}

	void OnCollisionExit2D(Collision2D collision) 
	{

	}

	void OnCollisionEnter2D(Collision2D collision)
	{

	}
}
