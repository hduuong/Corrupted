using UnityEngine;
using System.Collections;

public class bg1 : MonoBehaviour {
	public float delayTime;
	public bool flag;
	public float rate;
	// Use this for initialization
	void Start () {
		flag = true;
	}
	
	// Update is called once per frame
	void Update () {
		delayTime -= Time.deltaTime;
		if(delayTime <= 0){
			Color color = this.GetComponent<SpriteRenderer>().material.color;
			if(color.a <= 0){
				flag = false;
			}
			if(color.a >= 1){
				flag = true;
			}
			if(!flag){
				color.a += rate;
				this.GetComponent<SpriteRenderer>().material.color = color;
			}else{
				color.a -= rate;
				this.GetComponent<SpriteRenderer>().material.color = color;
			}
		}
	}
}