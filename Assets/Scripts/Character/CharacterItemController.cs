using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterItemController : MonoBehaviour {

	public List<ItemTypes> items = new List<ItemTypes>();

	public List<UnityEngine.UI.Image> invimg = new List<UnityEngine.UI.Image>();

	public Sprite foodImg;
	public Sprite medImg;
	public Sprite waterImg;
	public Sprite toolImg;
	
	DistanceToVictims distancesToVictims;
	
	// Use this for initialization
	void Start () {
		distancesToVictims = this.GetComponent<DistanceToVictims> ();

		foreach (UnityEngine.UI.Image i in invimg) {
			i.enabled = false;
		}


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
					Debug.Log(returnedItem);
					items.RemoveAt(0);
					items.Add(returnedItem);
					int invNum = items.Count - 1;
					Mathf.Clamp(invNum, 0,3);

					switch (returnedItem) 
					{
					case ItemTypes.None:
					{
						break;
					}
					case ItemTypes.Food:
					{
						invimg[invNum].enabled = true;
						invimg[invNum].sprite = foodImg;
						break;
					}
					case ItemTypes.Tools:
					{
						invimg[invNum].enabled = true;
						invimg[invNum].sprite = toolImg;
						break;
					}
					case ItemTypes.Water:
					{
						invimg[invNum].enabled = true;
						invimg[invNum].sprite = waterImg;
						break;
					}
					case ItemTypes.Medicine:
					{
						invimg[invNum].enabled = true;
						invimg[invNum].sprite = medImg;
						break;
					}
					}
				
				}
		
			}
		}

	}
}
