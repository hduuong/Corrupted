using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CorruptionBar : MonoBehaviour {
	Image image;   //the image it attached to
	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
	}
	public float getFillAmount(){
		return image.fillAmount;
	}
	// Update is called once per frame
	void Update () {
		//image.fillAmount = Mathf.Lerp (image.fillAmount, 0f, Time.deltaTime * 0.1f);
	}
}
