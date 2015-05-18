using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	//A parent class
	public bool toDelete;
	new public string name;
	public GameObject[] neibors;
	public int neiborsCount;
	public GameObject gameManager;
	public bool setDeleteCalled;

	// Use this for initialization
	protected void Start () {
		gameManager = GameObject.Find ("GameManager");
		toDelete = false;
		neibors = new GameObject[8];
		neiborsCount = 0;
		setDeleteCalled = false;
	}
	protected void setName(string s){
		name = s;
	}

	public void addNeibor(ref GameObject go){
		if (go == null)
			return;
		if (go.GetComponent<Tile>().name == this.name) {
			neibors [neiborsCount++] = go;
		}
	}

	public void disableNeibor(){
		if (neiborsCount == 0)
			return;
		for (int i = 0; i < 8; i++) {
			neibors[i] = null;
		}
		neiborsCount = 0;
	}
	public bool isMarkedDelete(){
		return toDelete;
	}

	public void setDelete(){
		setDeleteCalled = true;
		for (int i = 0; i < 8; i++) {
			if(neibors[i] != null && !neibors[i].GetComponent<Tile>().setDeleteCalled){
				neibors[i].GetComponent<Tile>().setDelete();
			}
		}
		toDelete = true;
	}
	// Update is called once per frame
	protected void Update () {
		if (toDelete) {
			if(this.name == "blue"){
				gameManager.GetComponent<GameManager>().blueOut--;
			}else if (this.name == "red"){
				gameManager.GetComponent<GameManager>().redOut--;
			}else if (this.name == "yellow"){
				gameManager.GetComponent<GameManager>().yellowOut--;
			}else {}
			Destroy(gameObject);
		}
	}
}
