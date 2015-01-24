using UnityEngine;
using System.Collections;

public class VictimItemDisplay : MonoBehaviour {

	ItemTypes currentItem = ItemTypes.None;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		SpriteRenderer renderer = this.GetComponent<SpriteRenderer> ();
		renderer.enabled = true;

		//Todo change this to the enum values
		//once the item types are set
		switch (currentItem) 
		{
			case ItemTypes.None:
			{
				renderer.enabled = false;
				break;
			}
			case ItemTypes.Food:
			{
				renderer.color = Color.blue;
				break;
			}
			case ItemTypes.Tools:
			{
				renderer.color = Color.yellow;
				break;
			}
			case ItemTypes.Water:
			{
				renderer.color = Color.green;
				break;
			}
			case ItemTypes.Medicine:
			{
				renderer.color = Color.cyan;
				break;
			}
		}
	}

	public void SetItem(ItemTypes itemType)
	{
		this.currentItem = itemType;
	}
}
