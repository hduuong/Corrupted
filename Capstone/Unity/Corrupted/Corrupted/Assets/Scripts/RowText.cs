using UnityEngine;
using System.Collections;

public class RowText : MonoBehaviour {
	public GameObject gm;      //the game manager
	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager");
		this.GetComponent<TextMesh> ().text = (gm.GetComponent<GameManager> ().cols - 6).ToString ();
	}
	
	// Update is called once per frame
	public void change () {
		string t = this.GetComponent<TextMesh> ().text;
		int num = int.Parse (t);
		if (num > 0) {
			num--;
		}
		this.GetComponent<TextMesh> ().text = num.ToString ();
	}
}
