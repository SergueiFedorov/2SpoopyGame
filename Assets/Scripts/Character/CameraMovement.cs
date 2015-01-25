using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

 
	public Transform Player;
	public float CamSpeed = 3.0f;


	void Start ()
	{

	}
	void Update()
	{
		transform.position = new Vector3(0,0,-10) + (Vector3)Vector2.Lerp (transform.position, Player.position, CamSpeed * Time.fixedDeltaTime);

	}

}
