using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {
	public GameObject gameManager;
	public GameObject projectTile;
	public Object [] cubes;
	public int shift;
	public bool shot;
	public int updateCounter;      //update the tile Array every # of frame
	public int turnCounter;        //keeps track of how many time the player shoots
	AudioSource shoot;             //the audio of shooting 
	public Vector3 lastMousePosition;     //the y position of mouse
	public Vector3 currentMousePosition;
	// Use this for initialization
	void Start () {
		int xPos = (int) this.transform.position.x;
		int yPos = (int) this.transform.position.y;
		updateCounter = 0;
		shot = false;
		lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		shoot = gameObject.AddComponent<AudioSource> ();
		shoot.clip = Resources.Load ("Sounds/shoot") as AudioClip;

		gameManager = GameObject.Find ("GameManager");
		shift = gameManager.GetComponent<GameManager> ().shiftSpace;
		cubes = Resources.LoadAll ("Prefabs/Tile", typeof(GameObject));
		projectTile = (GameObject)Instantiate (cubes[Random.Range(0,3)], new Vector2(xPos,yPos), Quaternion.identity);
		projectTile.name = (gameManager.GetComponent<GameManager> ().nameCounter++).ToString();
		projectTile.transform.parent = this.transform;
		projectTile.GetComponent<SpriteRenderer>().enabled = false;
		gameManager.GetComponent<GameManager> ().updateLaser ();
	}
	
	// Update is called once per frame
	void Update () {
		int xPos = (int) this.transform.position.x;
		int yPos = (int) this.transform.position.y;
		int zPos = (int) this.transform.position.z;
		currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		updateTileArray ();

		if ((int)currentMousePosition.y - (int)lastMousePosition.y != 0) {
			if ((int)currentMousePosition.y >= 0 - shift && (int)currentMousePosition.y < gameManager.GetComponent<GameManager>().rows - (shift)) {
				this.transform.position = new Vector3(xPos,(int)currentMousePosition.y,zPos);
				gameManager.GetComponent<GameManager>().updateLaser();
				lastMousePosition = currentMousePosition;
			}
		} 
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if(yPos > 0 - shift){
				this.transform.position = new Vector3(xPos,yPos-1,zPos);
				gameManager.GetComponent<GameManager>().updateLaser();
			}
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if(yPos < gameManager.GetComponent<GameManager>().rows - (shift+1)){
				this.transform.position = new Vector3(xPos,yPos+1,zPos);
				gameManager.GetComponent<GameManager>().updateLaser();
			}
		}
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
			shoot.Play();
			shot = true;
			turnCounter++;
			projectTile.GetComponent<SpriteRenderer>().enabled = true;
			//
			if(gameManager.GetComponent<GameManager>().addTile(projectTile)){
				makeTile();
			}
		}
		if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space)) {
			//gameManager.GetComponent<GameManager>().pushArrayDown();
			shot = false;
		}

		if (turnCounter % 5 == 0 && turnCounter != 0) {
			turnCounter = 0;
			gameManager.GetComponent<GameManager>().pushArrayDown();
			gameManager.GetComponent<GameManager>().totalCols--;
		}
	}

	public void updateTileArray(){
		int blueOut = gameManager.GetComponent<GameManager> ().blueOut;
		int redOut = gameManager.GetComponent<GameManager> ().redOut;
		int yellowOut = gameManager.GetComponent<GameManager> ().yellowOut;  

		if (blueOut == 0 && yellowOut == 0 && redOut == 0)    //THE GAME IS FINISHED
			return;
		if (blueOut == 0 && redOut == 0 && yellowOut != 0) {
			cubes = new Object[1];
			cubes[0] = Resources.Load ("Prefabs/Tile/TileTintYellow", typeof(GameObject));
		} else if (blueOut == 0 && redOut != 0 && yellowOut == 0) {
			cubes = new Object[1];
			cubes[0] = Resources.Load ("Prefabs/Tile/TileTintRed", typeof(GameObject));
		} else if (blueOut == 0 && redOut != 0 && yellowOut != 0) {
			cubes = new Object[2];
			cubes[0] = Resources.Load ("Prefabs/Tile/TileTintYellow", typeof(GameObject));
			cubes[1] = Resources.Load ("Prefabs/Tile/TileTintRed", typeof(GameObject));
		} else if (blueOut != 0 && redOut == 0 && yellowOut == 0) {
			cubes = new Object[1];
			cubes[0] = Resources.Load ("Prefabs/Tile/TileTintBlue", typeof(GameObject));
		} else if (blueOut != 0 && redOut == 0 && yellowOut != 0) {
			cubes = new Object[2];
			cubes[0] = Resources.Load ("Prefabs/Tile/TileTintBlue", typeof(GameObject));
			cubes[1] = Resources.Load ("Prefabs/Tile/TileTintYellow", typeof(GameObject));
		} else if (blueOut != 0 && redOut != 0 && yellowOut == 0) {
			cubes = new Object[2];
			cubes[0] = Resources.Load ("Prefabs/Tile/TileTintBlue", typeof(GameObject));
			cubes[1] = Resources.Load ("Prefabs/Tile/TileTintRed", typeof(GameObject));
		} else {
			cubes = Resources.LoadAll ("Prefabs/Tile", typeof(GameObject));
		}
	}

	void makeTile(){
		int xPos = (int) this.transform.position.x;
		int yPos = (int) this.transform.position.y;
		if (cubes.Length == 1)
			projectTile = (GameObject)Instantiate (cubes [Random.Range (0, 1)], new Vector2 (xPos, yPos), Quaternion.identity);
		else if (cubes.Length == 2)
			projectTile = (GameObject)Instantiate (cubes [Random.Range (0, 2)], new Vector2 (xPos, yPos), Quaternion.identity);
		else if (cubes.Length == 3)
			projectTile = (GameObject)Instantiate (cubes [Random.Range (0, 3)], new Vector2 (xPos, yPos), Quaternion.identity);
		else {}
		projectTile.name = (gameManager.GetComponent<GameManager> ().nameCounter++).ToString();
		projectTile.transform.parent = this.transform;   //stick it with the player so it moves along with the control
		projectTile.GetComponent<SpriteRenderer>().enabled = false;
		gameManager.GetComponent<GameManager>().updateLaser();
	}

	public GameObject createTile(){
		int xPos = (int) this.transform.position.x;
		int yPos = (int) this.transform.position.y;
		GameObject go = null;
		if (cubes.Length == 1)
			go = (GameObject)Instantiate (cubes [Random.Range (0, 1)], new Vector2 (xPos, yPos), Quaternion.identity);
		else if (cubes.Length == 2)
			go = (GameObject)Instantiate (cubes [Random.Range (0, 2)], new Vector2 (xPos, yPos), Quaternion.identity);
		else if (cubes.Length == 3)
			go = (GameObject)Instantiate (cubes [Random.Range (0, 3)], new Vector2 (xPos, yPos), Quaternion.identity);
		else {}
		go.name = (gameManager.GetComponent<GameManager> ().nameCounter++).ToString();
		return go;
	}
}
