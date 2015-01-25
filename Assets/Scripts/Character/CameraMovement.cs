using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

 
	public Transform Player;
	public float CamSpeed = 3.0f;
	public float minX;
	public float maxX;


	void Start ()
	{
		PlayerPrefs.SetInt ("CurLives", 6);
	}
	void Update()
	{
		transform.position = new Vector3(0,0,-10) + (Vector3)Vector2.Lerp (transform.position, Player.position, CamSpeed * Time.fixedDeltaTime);
		Vector3 tmpCam = transform.position;
		tmpCam.x = Mathf.Clamp (tmpCam.x, minX, maxX);
		transform.position = tmpCam;
	}

}
