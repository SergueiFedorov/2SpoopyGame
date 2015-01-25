using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
	Animator anim;

	public float minX;
	public float maxX;

	void Start () {

		anim = GetComponent<Animator> ();
		originalScale = this.transform.localScale;
	}

	Vector2 raycastDirection = new Vector2(0.0f, -1.0f);

	float jumpForce = 400.0f;

	int dropTimer = 0;

	Vector2 originalScale;

	// Update is called once per frame
	void FixedUpdate () {

		dropTimer--;

		RaycastHit2D raycastHit = default(RaycastHit2D);

		raycastHit = Physics2D.Raycast ((Vector2)this.transform.position - (Vector2.up * this.collider2D.bounds.size.y * 0.55f), raycastDirection, 0.05f);
		if (raycastHit.collider != null) 
		{
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

		if (Input.GetButtonDown ("DROP") || Input.GetKeyDown(KeyCode.LeftShift) && raycastHit.collider != null)
		{
			rigidbody2D.AddForce(Vector2.up * 150.0f);
			dropTimer = 30;
		}

		if (rigidbody2D.velocity.x < -0.05f)
		{
			this.transform.localScale = new Vector2(originalScale.x * -1.0f, originalScale.y);
		}
		else if (rigidbody2D.velocity.x > 0.05f)
		{
			this.transform.localScale = originalScale;
		}

//		Debug.Log (dropTimer);

		Vector2 tempLocation = this.transform.position;
		tempLocation.x = Mathf.Clamp (tempLocation.x, minX, maxX);
		this.transform.position = tempLocation;

		anim.SetFloat ("speed", Mathf.Abs(rigidbody2D.velocity.x));
		anim.SetFloat ("verticleSpeed", Mathf.Abs(rigidbody2D.velocity.y));

		if (dropTimer < 0)
		{
			Physics2D.IgnoreLayerCollision(this.gameObject.layer, LayerMask.NameToLayer("platform"), rigidbody2D.velocity.y > 0.0f);
		}
		else
		{
			Physics2D.IgnoreLayerCollision( this.gameObject.layer, LayerMask.NameToLayer("platform"), true);
		}
	}
}
