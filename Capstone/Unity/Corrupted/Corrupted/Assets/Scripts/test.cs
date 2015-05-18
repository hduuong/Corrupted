using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	public int rows;               //the number of rows for TILES
	public int cols;               //the number of cols for TILES
	public int offsetSpace;        //the space between the tiles and the player
	public int shiftSpace;         //the space that use to shift from the origin
	public int totalCols;          //the total collumns of the array
	public GameObject player;      //the player
	public GameObject [][] pieces; //the backend Array that store all game objects
	public Object [] cubes;        //the array that stores assets for cube instantiation
	public Object [] lasers;       //the array that keeps track of the laser indicator
	public GameObject firewall;    //the firewall appears at index j = 2;
	public AudioSource clear;      //the clear sound
	
	public int nameCounter;        //this is a name counter for all the tile in the game, their name going to be used when adding to the delete List
	public int shootCount;         //this is a counter to keep track of the number of shoot
	public int redOut;             //this is the number of red tile in game
	public int blueOut;            //this is the number of blue tile in game
	public int yellowOut;          //this is the number of yellow tile in game  
	public bool firewallisOn;     //this bool flag is used to notify whether to or not to check for its visibility
	public bool findTileCountOnce;//this bool flag is used to find all the blue-red-yellow counts when first enter the game
	public bool findNeiborsOnce;  //this bool flag is used to link up the neibors for every tile in the beginning once
	public int laserFirstUpdate;  //this acts as a flag - but delays for 5 frame - because it has to wait for the projectile to finish initializing
	public int laserFireUpdate;   //this acts as a flag - but delays for 5 frame - because it has to wait for the projectile to finish initializing
	// Use this for initialization
	void Start () {
		firewallisOn = false;
		redOut = 0;
		blueOut = 0;
		yellowOut = 0;
		findNeiborsOnce = false;
		findTileCountOnce = false;
		laserFirstUpdate = 5;
		laserFireUpdate = 5;
		totalCols = cols + offsetSpace;
		nameCounter = 0;
		
		clear = gameObject.AddComponent<AudioSource> ();
		clear.clip = Resources.Load ("Sounds/clear") as AudioClip;
		
		lasers = new GameObject[totalCols];
		firewall = GameObject.Find ("firewall");
		firewall.GetComponent<SpriteRenderer>().enabled = false;
		
		pieces = new GameObject[totalCols][];
		//------------------------------------Instantiating the Titles----------------------------------------------
		cubes = Resources.LoadAll ("Prefabs/Color Cubes", typeof(GameObject));
		for (int i = offsetSpace; i < totalCols; i++) {
			pieces[i] = new GameObject[rows];
			for (int j = 0; j < rows; j++) {
				Debug.Log("here here");
				pieces[i][j] = (GameObject)Instantiate (cubes[Random.Range(0,3)], new Vector2(i,j - shiftSpace), Quaternion.identity);
				pieces[i][j].name = (nameCounter++).ToString();
			}
		}
		//------------------------------------Instantiating the Player----------------------------------------------	
		player = (GameObject)Instantiate(Resources.Load("Prefabs/Cannon", typeof(GameObject)),new Vector2(0,0 - shiftSpace + rows/2), Quaternion.identity);
		pieces[0][0] = player;
	}
}
