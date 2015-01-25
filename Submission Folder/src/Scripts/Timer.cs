using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public UnityEngine.UI.Slider time;
	void DecrementTime()
	{
		time.value -= 1.0f;
		}
	// Use this for initialization
	void Start () {
		InvokeRepeating ("DecrementTime", 1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
