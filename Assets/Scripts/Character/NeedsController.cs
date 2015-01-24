using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NeedsController : MonoBehaviour {

	Dictionary<KeyCode, VictimNeeds> needBindings = new Dictionary<KeyCode, VictimNeeds>();

	DistanceToVictims distancesToVictims;

	VictimNeeds currentNeedBeingAsked;

	// Use this for initialization
	void Start () {
		needBindings.Add (KeyCode.A, VictimNeeds.Build);
		needBindings.Add (KeyCode.S, VictimNeeds.Hunger);
		needBindings.Add (KeyCode.D, VictimNeeds.Sick);
		needBindings.Add (KeyCode.F, VictimNeeds.Thirst);

		distancesToVictims = this.GetComponent<DistanceToVictims> ();
	}
	
	// Update is called once per frame
	void Update () {

		Victim victim = distancesToVictims.GetClosestVictim ();

		//Debug.Log (victim);

		if (victim != null)
		{
			foreach (KeyValuePair<KeyCode, VictimNeeds> binding in needBindings) 
			{
				currentNeedBeingAsked = VictimNeeds.None;
				if (Input.GetKeyDown(binding.Key))
				{
					currentNeedBeingAsked = binding.Value;
					break;
				}
			}

			if (currentNeedBeingAsked != VictimNeeds.None)
			{

				if (victim.need == currentNeedBeingAsked)
				{
					Debug.Log("yes");
				}
				else
				{
					Debug.Log("No");
				}

			}


		}

	}
}
