using UnityEngine;
using System.Collections;
using System.Net;

public class Victim : MonoBehaviour {

	public ItemTypes need;
	private ItemTypes itemType = ItemTypes.Food;
	bool showHiddenItem = false;
	Healthbar healthBar; 

	public Sprite yes;
	public Sprite no;

	public Sprite originalSprite;

	int imageResponseTimer = - 1;

	static int lastGeneratedRandomValue = 0;

	private void ResetVictimWithNewValues()
	{
		int currentValue = Random.Range(1, (int)ItemTypes.MaxValue);
		lastGeneratedRandomValue = currentValue;

		itemType = (ItemTypes)(currentValue);
		
		while (itemType == need)
		{
			need = (ItemTypes)Random.Range(1, (int)ItemTypes.MaxValue);
		}
	}

	int resetTimer = -1;

	// Use this for initialization
	void Start () {
		this.healthBar = transform.Find ("VictimHealthBar").GetComponent<Healthbar> ();
		this.originalSprite = this.GetComponent<SpriteRenderer> ().sprite;
		this.ResetVictimWithNewValues ();
	}
	
	// Update is called once per frame
	void Update () {
		if (showHiddenItem)
		{
			GameObject obj = transform.Find ("ItemTypeIndicator").gameObject;
			obj.GetComponent<VictimItemDisplay> ().SetItem (itemType);
		}
		else
		{
			GameObject obj = transform.Find ("ItemTypeIndicator").gameObject;
			obj.GetComponent<VictimItemDisplay> ().SetItem (ItemTypes.None);
		}

		resetTimer -= 1;
		imageResponseTimer -= 1;

		if (imageResponseTimer < 0)
		{
			showHiddenItem = false;
			this.GetComponent<SpriteRenderer>().sprite = originalSprite;
		}

		/*
		if (resetTimer < 0)
		{
			rende
			showHiddenItem = false;
			this.ResetVictimWithNewValues();
		}*/
	}

	public bool CanTrade(ItemTypes item)
	{
		return item == need;
	}

	public ItemTypes DoTrade(ItemTypes item)
	{
		ItemTypes myItem = this.itemType;
		this.itemType = item;

		return myItem;
	}

	const float HEALTH_DECREMENT = 1.0f;

	public void GesureFailed()
	{
		this.GetComponent<SpriteRenderer> ().sprite = no;
		imageResponseTimer = 100;

		healthBar.DecrementHealth (HEALTH_DECREMENT);
	}

	public void SetGestureSucceeded()
	{
		showHiddenItem = true;

		this.GetComponent<SpriteRenderer> ().sprite = yes;
		imageResponseTimer = 100;

		healthBar.ResetHealthToFull ();
	}

	public bool TryGesture(ItemTypes gestureForItem)
	{
		return this.need == gestureForItem;
	}
}
