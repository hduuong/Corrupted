using UnityEngine;
using System.Collections;

public class burstVirus : MonoBehaviour {
	public Object[] viruses;
	public int shiftSpace;
	public GameObject gm;
	// Use this for initialization
	void Start () {
		viruses = Resources.LoadAll ("Prefabs/BurstVirus", typeof(GameObject));
		gm = GameObject.Find ("GameManager");
		shiftSpace = gm.GetComponent<GameManager> ().shiftSpace;

	}

	public void getColor(){
		int i = (int)(this.transform.position.x);
		int j = (int)(this.transform.position.y + shiftSpace);
		string color = gm.GetComponent<GameManager> ().pieces [i] [j].GetComponent<Tile> ().name;
		if (color == "red") {
			this.GetComponent<SpriteRenderer>().color = Color.red;
		} else if (color == "blue") {
			this.GetComponent<SpriteRenderer>().color = Color.blue;
		} else if (color == "yellow") {
			this.GetComponent<SpriteRenderer>().color = Color.yellow;
		} else {
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
