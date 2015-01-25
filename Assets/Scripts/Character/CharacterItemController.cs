using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;



public class CharacterItemController : MonoBehaviour {

	private Sprite GetSpriteForEnum(ItemTypes types)
	{
		switch (types) 
		{
			case ItemTypes.Food:
			{
				return foodImg;
			}
			case ItemTypes.Cold:
			{
				return coldImg;
			}
			case ItemTypes.Water:
			{
				return waterImg;
			}
			case ItemTypes.Medicine:
			{
				return medImg;
			}
			default:
			{
				throw new UnityException("No image associated with " + types);
			}
		}

		return null;
	}
	
	public List<ItemTypes> items = new List<ItemTypes>();
	public List<Image> inventoryItemImage = new List<Image>();

	public Sprite foodImg;
	public Sprite medImg;
	public Sprite waterImg;
	public Sprite coldImg;
	
	DistanceToVictims distancesToVictims;


	
	// Use this for initialization
	void Start () {
		distancesToVictims = this.GetComponent<DistanceToVictims> ();

		foreach (UnityEngine.UI.Image image in inventoryItemImage) {
			image.enabled = false;
		}

		if (this.inventoryItemImage.Count != this.items.Count)
		{
			throw new UnityException("You have too many items. Not enough UI space.");
		}

		for (int x = 0; x < this.inventoryItemImage.Count; x++)
		{
			this.inventoryItemImage[x].enabled = true;
			this.inventoryItemImage[x].sprite = GetSpriteForEnum(this.items[x]);
		}
	}

	private static class JoystickStrings
	{
		public const string SQUARE = "JOYSTICK_SQUARE";
		public const string CIRCLE = "JOYSTICK_CIRCLE";
		public const string TRIANGLE = "JOYSTICK_TRIANGLE";
	}

	int TranslateJoystickToItemPosition(string joystickButtonString)
	{
		switch (joystickButtonString)
		{
			case JoystickStrings.CIRCLE:
			{
				return 2;
			}
			case JoystickStrings.SQUARE:
			{
				return 0;
			}
			case JoystickStrings.TRIANGLE:
			{
				return 1;
			}
			default:
			{
				throw new UnityException("There is no such button string defined");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		Victim victim = distancesToVictims.GetClosestVictim ();

		if (victim != null)
		{
			int buttonPressedIndex = -1;
			if (Input.GetButtonDown(JoystickStrings.CIRCLE))
			{
				buttonPressedIndex = this.TranslateJoystickToItemPosition(JoystickStrings.CIRCLE);
			}
			else if (Input.GetButtonDown(JoystickStrings.SQUARE))
			{
				buttonPressedIndex = this.TranslateJoystickToItemPosition(JoystickStrings.SQUARE);
			}
			else if (Input.GetButtonDown(JoystickStrings.TRIANGLE))
			{
				buttonPressedIndex = this.TranslateJoystickToItemPosition(JoystickStrings.TRIANGLE);
			}

			if (buttonPressedIndex != -1)
			{
				if (victim.CanTrade(items[buttonPressedIndex]))
				{
					ItemTypes returnedItem = victim.DoTrade(items[buttonPressedIndex]);

					items[buttonPressedIndex] = returnedItem;

					this.inventoryItemImage[buttonPressedIndex].sprite = this.GetSpriteForEnum(returnedItem);

					victim.DeactivateFor(400);
				}
				else
				{
					victim.Kill();
				}
			}
		}

	}
}
