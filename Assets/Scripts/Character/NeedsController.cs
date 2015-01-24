using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NeedsController : MonoBehaviour {

	Dictionary<KeyCode, VictimNeeds> needBindings = new Dictionary<KeyCode, VictimNeeds>();

	// Use this for initialization
	void Start () {
		needBindings.Add (KeyCode.A, VictimNeeds.Build);
		needBindings.Add (KeyCode.S, VictimNeeds.Hunger);
		needBindings.Add (KeyCode.D, VictimNeeds.Sick);
		needBindings.Add (KeyCode.F, VictimNeeds.Thirst);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
