using UnityEngine;
using System.Collections;

public class RepairMeter : MonoBehaviour {
	public GameObject gm;      //the game manager
	public GameObject repairMeter; //the actual object that will be instantiate
	public Object [] meters;   //the array of repair meters
	public bool full;          //bool flag for the meter status
	public int lastIndex;      //last index number for making the meters
	public int index;          //index number for making the correct meter
	// Use this for initialization
	void Start () {
		index = 0;
		lastIndex = 0;
		meters = Resources.LoadAll ("Prefabs/Repair Meter", typeof(GameObject));
		gm = GameObject.Find ("GameManager");
		repairMeter = (GameObject)Instantiate (meters[index], new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
		if (!full) {
			if (index - lastIndex > 0) {
				Destroy (repairMeter);
				repairMeter = (GameObject)Instantiate (meters [index], new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
			}
			lastIndex = index;
		}
		if (index == 10) {
			full = true;
		}
	}
	//restart the meter when heal is used
	public void restart(){
		full = false;
		index = 0;
		lastIndex = 0;
		Destroy(repairMeter);
		repairMeter = (GameObject)Instantiate (meters[index], new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);

	}
}
