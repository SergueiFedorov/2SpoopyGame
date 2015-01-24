﻿using UnityEngine;
using System.Collections;

public class healthbar : MonoBehaviour {

	public float maxhealh = 3.0f;
	public float curhealth = 3.0f;
	public GameObject thehealthbar;

	private Vector3 startScale;

	
	// Use this for initialization
	void Start () {
		startScale = this.transform.localScale;
	}

	// Update is called once per frame
	void Update () {
		TheCurrentHealth (0);
	}

	
	public void TheCurrentHealth(int adj)
	{
		curhealth += adj;
		this.transform.localScale = (new Vector3((curhealth / maxhealh) * startScale.x, startScale.y,0));

		Debug.Log (this.transform.localScale);

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