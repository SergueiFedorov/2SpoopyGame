using UnityEngine;
using System.Collections;

public class Victim : MonoBehaviour {

	public ItemTypes need;
	private ItemTypes itemType = ItemTypes.Food;
	bool showHiddenItem = false;
	Healthbar healthBar; 

	public Sprite yes;
	public Sprite no;

	public Sprite originalSprite;

	int imageResponseTimer = - 1;

	// Use this for initialization
	void Start () {
		healthBar = transform.Find ("VictimHealthBar").GetComponent<Healthbar> ();
		itemType = (ItemTypes)Random.Range (1, (int)ItemTypes.MaxValue);

		while (itemType != need)
		{
			need = (ItemTypes)Random.Range (1, (int)ItemTypes.MaxValue);
		}

		originalSprite = this.GetComponent<SpriteRenderer> ().sprite;
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

		imageResponseTimer -= 1;

		//Debug.Log (imageResponseTimer);

		if (imageResponseTimer < 0)
		{
			showHiddenItem = false;
			this.GetComponent<SpriteRenderer>().sprite = originalSprite;
		}
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
