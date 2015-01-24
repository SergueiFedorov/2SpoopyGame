using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	Vector2 raycastDirection = new Vector2(0.0f, -1.0f);

	float jumpForce = 200.0f;

	// Update is called once per frame
	void Update () {


		RaycastHit2D raycastHit = default(RaycastHit2D);
		raycastHit = Physics2D.Raycast ((Vector2)this.transform.position - (Vector2.up * this.collider2D.bounds.size.y * 0.5f), raycastDirection, 0.05f);
		if (raycastHit.collider != null) 
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				this.rigidbody2D.AddForce(Vector2.up * jumpForce); 
			}
		}

		if (Input.GetKey (KeyCode.RightArrow) && rigidbody2D.velocity.x < 10.0f) 
		{
			rigidbody2D.AddForce(new Vector2(10, 0));
		}

		if (Input.GetKey (KeyCode.LeftArrow) && rigidbody2D.velocity.x > -10.0f) 
		{
			rigidbody2D.AddForce(new Vector2(-10, 0));
		}

		Physics2D.IgnoreLayerCollision(this.gameObject.layer, LayerMask.NameToLayer("platform"), rigidbody2D.velocity.y > 0.0f);

	}

	void OnCollisionExit2D(Collision2D collision) 
	{

	}

	void OnCollisionEnter2D(Collision2D collision)
	{

	}
}
