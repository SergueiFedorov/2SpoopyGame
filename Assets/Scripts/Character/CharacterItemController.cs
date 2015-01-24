using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterItemController : MonoBehaviour {

	public List<ItemTypes> items = new List<ItemTypes>();
	DistanceToVictims distancesToVictims;
	
	// Use this for initialization
	void Start () {
		distancesToVictims = this.GetComponent<DistanceToVictims> ();
	}
	
	// Update is called once per frame
	void Update () {

		Victim victim = distancesToVictims.GetClosestVictim ();

		if (victim != null)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1) && items.Count > 0)
			{
				if (victim.CanTrade(items[0]))
				{
					ItemTypes returnedItem = victim.DoTrade(items[0]);
					items.RemoveAt(0);
					items.Add(returnedItem);
				}
		
			}
		}

	}
}
