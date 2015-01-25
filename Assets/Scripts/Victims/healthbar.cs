using UnityEngine;
using System.Collections;

public class Healthbar : MonoBehaviour {


	public float maxhealh = 3.0f;
	public float curhealth;
	public GameObject thehealthbar;

	private Vector3 startScale;

	float startHealth;
	
	// Use this for initialization
	void Start () {
		startScale = this.transform.localScale;
		startHealth = curhealth = maxhealh;
	}

	// Update is called once per frame
	void Update () {
		this.transform.localScale = (new Vector3((curhealth / maxhealh) * startScale.x, startScale.y,0));
	}

	public void ResetHealthToFull()
	{
		Debug.Log (curhealth);

		curhealth = startHealth;
	}

	public void DecrementHealth(float adj)
	{
		curhealth -= adj;


		if (curhealth < 0) {
			curhealth = 0;
				}
		if (curhealth > maxhealh) {
			curhealth = maxhealh;
		}
		if (maxhealh < 1) {
			maxhealh = 1;
		}

	}


}
