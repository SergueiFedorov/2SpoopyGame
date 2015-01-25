using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class NeedsController : MonoBehaviour {

	Dictionary<KeyCode, ItemTypes> needBindingsKeyboard = new Dictionary<KeyCode, ItemTypes>();
	Dictionary<string, ItemTypes> needBindingsJoystick = new Dictionary<string, ItemTypes>();

	DistanceToVictims distancesToVictims;

	ItemTypes currentNeedBeingAsked;

	// Use this for initialization
	void Start () {
		needBindingsKeyboard.Add (KeyCode.A, ItemTypes.Food);
		needBindingsKeyboard.Add (KeyCode.S, ItemTypes.Medicine);
		needBindingsKeyboard.Add (KeyCode.D, ItemTypes.Cold);
		needBindingsKeyboard.Add (KeyCode.F, ItemTypes.Water);

		needBindingsJoystick.Add ("DPAD_UP", ItemTypes.Food);
		needBindingsJoystick.Add ("DPAD_RIGHT", ItemTypes.Medicine);
		needBindingsJoystick.Add ("DPAD_DOWN", ItemTypes.Cold);
		needBindingsJoystick.Add ("DPAD_LEFT", ItemTypes.Water);

		distancesToVictims = this.GetComponent<DistanceToVictims> ();
	}

	ItemTypes lastJoystickAxis;

	// Update is called once per frame
	void Update () {

		Victim victim = distancesToVictims.GetClosestVictim ();

		if (victim != null)
		{
			currentNeedBeingAsked = ItemTypes.None;

			foreach (KeyValuePair<KeyCode, ItemTypes> binding in needBindingsKeyboard) 
			{
				if (Input.GetKeyDown(binding.Key))
				{
					currentNeedBeingAsked = binding.Value;
					break;
				}
			}

			//foreach (KeyValuePair<string, ItemTypes> binding in needBindingsJoystick) 
			{


				//if (value > 0.1f || value < -0.1f)
				{
					ItemTypes currentAxis = ItemTypes.None;

					float value = Input.GetAxisRaw("DPAD_UP");
					//ItemTypes currentAxis = ItemTypes.None;

					//if (binding.Key == "DPAD_UP")
					{
						if (value > 0.1f)
						{
							currentAxis = needBindingsJoystick["DPAD_UP"];
						}
						if (value < -0.1f)
						{
							currentAxis = needBindingsJoystick["DPAD_DOWN"];
						}

					}

					value = Input.GetAxisRaw("DPAD_LEFT");

					//if (binding.Key == "DPAD_LEFT")
					{

						if (value > 0.1f)
						{
							currentAxis = needBindingsJoystick["DPAD_RIGHT"];
						}
						if (value < -0.1f)
						{
							currentAxis = needBindingsJoystick["DPAD_LEFT"];
						}
					}

					Debug.Log(lastJoystickAxis + " " + currentAxis);

					if (lastJoystickAxis != currentAxis)
					{
						currentNeedBeingAsked = currentAxis;
					}

					lastJoystickAxis = currentAxis;
				}
				//else
				{
					//lastJoystickAxis = ItemTypes.None;
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
