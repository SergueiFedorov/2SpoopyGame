using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	int left;
	int dead;

	public UnityEngine.UI.Text l;
	public UnityEngine.UI.Text d;

	// Use this for initialization
	void Start () {
		left = PlayerPrefs.GetInt ("CurLives");
		dead = 5 - left;

		l.text = left.ToString ();
		d.text = dead.ToString ();
	}
}
