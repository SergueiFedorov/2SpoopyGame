using UnityEngine;
using System.Collections;

public class VictimItemDisplay : MonoBehaviour {

	ItemTypes currentItem = ItemTypes.None;

	public Sprite MedicineIcon;
	public Sprite WaterIcon;
	public Sprite ColdIcon;
	public Sprite FoodIcon;

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
				renderer.sprite = FoodIcon;
				break;
			}
			case ItemTypes.Cold:
			{
				renderer.sprite = ColdIcon;
				break;
			}
			case ItemTypes.Water:
			{
				renderer.sprite = WaterIcon;
				break;
			}
			case ItemTypes.Medicine:
			{
				renderer.sprite = MedicineIcon;	
				break;
			}
		}
	}

	public void SetItem(ItemTypes itemType)
	{
		this.currentItem = itemType;
	}
}
