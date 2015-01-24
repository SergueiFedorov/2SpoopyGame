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
			if (Input.GetKey(KeyCode.Alpha1) && items.Count > 0)
			{
				ItemTypes selectedType = items[0];
				items.RemoveAt(0);

				ItemTypes itemToTradeIn = victim.itemType;

				victim.itemType = selectedType;
				items.Add(itemToTradeIn);

			}
		}
		//float axisValue = Input.GetAxisRaw ("Move_X");

		//Debug.Log ("Value: " + axisValue);

		/*
		foreach (string name in Input.GetJoystickNames ())
		{
			Debug.Log(name);
		}*/

		/*
		string output = "ME: ";
		Debug.ClearDeveloperConsole ();
		foreach (ItemTypes item in items)
		{
			output += item.ToString() + " ";
		}

		Debug.Log (output);

		if (victim != null)
		{
			Debug.Log ("VICTIM: " + victim.itemType);
		}*/

	}
}
