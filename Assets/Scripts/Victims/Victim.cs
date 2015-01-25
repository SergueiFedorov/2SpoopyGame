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

	int deactivateTimer = -1;

	Animator anim;
	public void DeactivateFor(int time)
	{
		this.ResetVictimWithNewValues ();
		this.deactivateTimer = time;
	}

	public bool IsActivated()
	{
		return this.deactivateTimer < 0;
	}

	private void ResetVictimWithNewValues()
	{
		int currentValue = Random.Range(1, (int)ItemTypes.MaxValue);

		itemType = (ItemTypes)(currentValue);
		
		while (itemType == need)
		{
			need = (ItemTypes)Random.Range(1, (int)ItemTypes.MaxValue);
		}

		//Debug.Log (itemType + " " + need);
	}

	int resetTimer = -1;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		this.healthBar = transform.Find ("VictimHealthBar").GetComponent<Healthbar> ();
		this.originalSprite = this.GetComponent<SpriteRenderer> ().sprite;
		this.ResetVictimWithNewValues ();
	}
	
	// Update is called once per frame
	void Update () {
		if (healthBar.curhealth <= 0.0f)
		{
			GameObject.Destroy(this.gameObject);

			return;
		}

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
		deactivateTimer -= 1;

		if (imageResponseTimer < 0)
		{
			showHiddenItem = false;
			this.GetComponent<SpriteRenderer>().sprite = originalSprite;
		}

		if (IsActivated() == false)
		{
			this.GetComponent<SpriteRenderer>().color = Color.gray;
		}
		else
		{
			anim.SetBool("Stress", true);
			this.GetComponent<SpriteRenderer>().color = Color.white;
		}
	}

	public void Kill()
	{
		this.healthBar.curhealth = 0.0f;
	}

	public bool CanTrade(ItemTypes item)
	{
		return item == need && this.IsActivated();
	}

	public ItemTypes DoTrade(ItemTypes item)
	{
		anim.SetBool ("Success", true);
		ItemTypes myItem = this.itemType;
		this.itemType = item;

		return myItem;
	}

	const float HEALTH_DECREMENT = 1.0f;

	public void GesureFailed()
	{
		anim.SetBool("Reject",true);
		this.GetComponent<SpriteRenderer> ().sprite = no;
		imageResponseTimer = 100;

		healthBar.DecrementHealth (HEALTH_DECREMENT);
	}

	public void SetGestureSucceeded()
	{
		anim.SetBool("Agree", true);
		showHiddenItem = true;

		this.GetComponent<SpriteRenderer> ().sprite = yes;
		imageResponseTimer = 100;

		healthBar.ResetHealthToFull ();
	}

	public bool TryGesture(ItemTypes gestureForItem)
	{
		return this.need == gestureForItem;
	}

	void ResetStressed()
	{
		anim.SetBool ("Stress", false);
		anim.SetBool ("Agree", false);
		anim.SetBool ("Reject", false);
	}

	void SetIdle()
	{
		anim.SetBool ("Success", false);
	}
}
