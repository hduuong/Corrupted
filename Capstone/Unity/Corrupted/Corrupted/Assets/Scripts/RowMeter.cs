using UnityEngine;
using System.Collections;

public class RowMeter : MonoBehaviour {
	public GameObject gm;      //the game manager
	public GameObject rowMeter; //the actual object that will be instantiate
	public Object [] meters;   //the array of repair meters
	public int index;          //index number for making the correct meter
	public int pushedCols;     //the number of cols got pushed into game view
	public float percentage;   //the percentage between total and pushed cols
	public int lastIndex;      //the last index - use to compare
	// Use this for initialization
	void Start () {
		index = 9;
		lastIndex = index;
		pushedCols = 8;
		meters = Resources.LoadAll ("Prefabs/Row Meter", typeof(GameObject));
		gm = GameObject.Find ("GameManager");
		rowMeter = (GameObject)Instantiate (meters[index], new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		percentage = 100 - percentage_cal ();
		index = (int)percentage / 10;
		if (index < lastIndex) {
			Destroy (rowMeter);
			rowMeter = (GameObject)Instantiate (meters [index], new Vector2 (this.transform.position.x, this.transform.position.y), Quaternion.identity);
			lastIndex = index;		
		}
	}

	float percentage_cal(){
		return (pushedCols * 100.0f / gm.GetComponent<GameManager> ().totalCols);
	}
}
