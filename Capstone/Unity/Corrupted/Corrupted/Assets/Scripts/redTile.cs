using UnityEngine;
using System.Collections;

public class redTile : Tile {
	// Use this for initialization
	new protected void Start () {	
		base.Start ();
		base.setName ("red");
	}
	
	// Update is called once per frame
	new protected void Update () {
		base.Update ();
	}
}
