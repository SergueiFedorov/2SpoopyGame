using UnityEngine;
using System.Collections;

public class Victim : MonoBehaviour {

	public ItemTypes need;
	private ItemTypes itemType = ItemTypes.Food;
	bool gestureWasSuccesful = false;

	Healthbar healthBar; 

	// Use this for initialization
	void Start () {
		healthBar = transform.Find ("VictimHealthBar").GetComponent<Healthbar> ();
		itemType = (ItemTypes)Random.Range (1, (int)ItemTypes.MaxValue - 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (gestureWasSuccesful)
		{
			GameObject obj = transform.Find ("ItemTypeIndicator").gameObject;
			obj.GetComponent<VictimItemDisplay> ().SetItem (itemType);
		}

		//transform.Find ("VictimHealthBar").GetComponent<healthbar>().set
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
		healthBar.DecrementHealth (HEALTH_DECREMENT);
	}

	public void SetGestureSucceeded()
	{
		gestureWasSuccesful = true;
	}

	public bool TryGesture(ItemTypes gestureForItem)
	{
		return this.need == gestureForItem;
	}
}
