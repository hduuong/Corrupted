using UnityEngine;
using System.Collections;

public class CorruptionMarker : MonoBehaviour {
	public Object[] list;       //a list of different corruption marker
	public GameObject marker;   //the marker
	public GameObject bar;
	public bool lose;
	// Use this for initialization
	void Start () {
		list = Resources.LoadAll ("Prefabs/Corruption Markers");
		bar = GameObject.Find ("FillColor");
		lose = false;
		marker = (GameObject)Instantiate (list[0], new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		float value = bar.GetComponent<CorruptionBar> ().getFillAmount ();
		if (value >= 0f && value < 0.125f) {
			Destroy(marker);
			marker = (GameObject)Instantiate (list[0], new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
		} else if (value >= 0.125f && value < 0.250f) {
			Destroy(marker);
			marker = (GameObject)Instantiate (list[1], new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
		} else if (value >= 0.250f && value < 0.375f) {
			Destroy(marker);
			marker = (GameObject)Instantiate (list[2], new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
		} else if (value >= 0.375f && value < 0.55f){
			Destroy(marker);
			marker = (GameObject)Instantiate (list[3], new Vector2(this.transform.position.x,this.transform.position.y), Quaternion.identity);
		}else{
			lose = true;
		}
	}
}
