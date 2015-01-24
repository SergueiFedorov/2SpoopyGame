using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DistanceToVictims : MonoBehaviour {

	public string VictimTag;
	public float detectionDistance = 1.0f;

	private List<GameObject> VictimsCloseBy = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.VictimsCloseBy.Clear ();

		IEnumerable<GameObject> objects = GameObject.FindGameObjectsWithTag (VictimTag);

		foreach (GameObject obj in objects) 
		{
			if (Vector3.Distance(obj.transform.position, this.transform.position) <= detectionDistance)
			{
				VictimsCloseBy.Add(obj);
			}
		}

		//Debug.Log (this.VictimsCloseBy.Count);
	}

	public Victim GetClosestVictim()
	{
		GameObject obj = this.VictimsCloseBy.OrderBy(x => Vector3.Distance(x.gameObject.transform.position, this.transform.position)).FirstOrDefault();
		if (obj == null)
		{
			return null;
		}
		return obj.GetComponent<Victim> ();
	}
}
