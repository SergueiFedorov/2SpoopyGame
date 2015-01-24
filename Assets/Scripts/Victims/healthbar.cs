using UnityEngine;
using System.Collections;

public class healthbar : MonoBehaviour {

	public float maxhealh = 3;
	public float curhealth = 3;
	public GameObject thehealthbar;

	
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		TheCurrentHealth (0);
	}

	
	public void TheCurrentHealth(int adj)
	{
		curhealth += adj;
		thehealthbar.transform.localScale = new Vector3((curhealth/maxhealh)*9,2,0);


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
