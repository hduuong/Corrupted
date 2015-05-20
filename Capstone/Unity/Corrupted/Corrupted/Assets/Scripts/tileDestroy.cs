using UnityEngine;
using System.Collections;

public class tileDestroy : MonoBehaviour {
	public float selfDestructTime;
	// Use this for initialization
	void Start () {
		selfDestructTime = 0.25f;
	}
	
	// Update is called once per frame
	void Update () {
		selfDestructTime -= Time.deltaTime;
		if(selfDestructTime <= 0){
			Destroy(gameObject);
		}
	}
}
