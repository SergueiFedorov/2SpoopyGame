using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NeedsController : MonoBehaviour {

	Dictionary<KeyCode, ItemTypes> needBindings = new Dictionary<KeyCode, ItemTypes>();

	DistanceToVictims distancesToVictims;

	ItemTypes currentNeedBeingAsked;

	// Use this for initialization
	void Start () {
		needBindings.Add (KeyCode.A, ItemTypes.Food);
		needBindings.Add (KeyCode.S, ItemTypes.Medicine);
		needBindings.Add (KeyCode.D, ItemTypes.Tools);
		needBindings.Add (KeyCode.F, ItemTypes.Water);

		distancesToVictims = this.GetComponent<DistanceToVictims> ();
	}
	
	// Update is called once per frame
	void Update () {

		Victim victim = distancesToVictims.GetClosestVictim ();

		if (victim != null)
		{
			foreach (KeyValuePair<KeyCode, ItemTypes> binding in needBindings) 
			{
				currentNeedBeingAsked = ItemTypes.None;
				if (Input.GetKeyDown(binding.Key))
				{
					currentNeedBeingAsked = binding.Value;
					break;
				}
			}

			if (currentNeedBeingAsked != ItemTypes.None)
			{
				if (victim.TryGesture(currentNeedBeingAsked))
				{
					victim.SetGestureSucceeded();
				}
				else
				{
					victim.GesureFailed();
				}
			}
		}

	}
}
