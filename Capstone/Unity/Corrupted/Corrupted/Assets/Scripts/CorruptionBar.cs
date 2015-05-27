using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CorruptionBar : MonoBehaviour {
	Image image;   //the image it attached to
	public float percentage;
	GameObject gm;
	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager");
		image = GetComponent<Image> ();
		percentage = 0.0f;
	}
	public float getFillAmount(){
		return image.fillAmount;
	}

	// Update is called once per frame
	void Update () {
		int corruptionCount = gm.GetComponent<GameManager> ().corruptionCount;
		int rows = gm.GetComponent<GameManager> ().rows;
		int visibleCols = gm.GetComponent<GameManager>().visibleCols;
		percentage = (corruptionCount * 1.0f/ (visibleCols * rows));
		image.fillAmount = percentage;
	}
}
