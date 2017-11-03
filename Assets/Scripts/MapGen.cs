using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour {

	public static Vector2 mapBounds = new Vector2 (100, 100);
	public GameObject tile;
	public Color[] colors = new Color[2];
	private Tile[,] tiles = new Tile[(int)mapBounds.x,(int)mapBounds.y];

	public int greenThreshold = 4;
	public int blueThreshold = 4;

	public float noise = .01f;

	// Use this for initialization
	void Start () {
		colors [0] = Color.green;
		colors [1] = Color.blue;
		Generate ();
	}

	void Generate (){
		for (int y = 0; y < mapBounds.y; y++) {
			for (int x = 0; x < mapBounds.x; x++) {
				int color = Random.Range (0, 2);
				tiles[x,y] = new Tile(Instantiate (tile,new Vector3(x, y),tile.transform.rotation), colors[color], new Vector2(x,y));
				if (overrideNeighbor (Color.green, tiles [x, y], greenThreshold)) {
					tiles [x, y].setColor (Color.green);
				}
				if (overrideNeighbor (Color.blue, tiles [x, y], blueThreshold)) {
					tiles [x, y].setColor (Color.blue);
				}
				//add a little more randomness
				float rand = Random.value;
				if ((1.0f - rand) < noise)
					tiles [x, y].setColor (Color.green);
				if (rand < noise)
					tiles [x, y].setColor (Color.blue);
			}
		}
	}

	bool overrideNeighbor(Color color, Tile tile, int threshold){
		List<Tile> neighbors = new List<Tile>();
		Vector2 pos = tile.getPosition ();
		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				if (inRange(new Vector2(pos.x + x, pos.y + y)) &&tiles [(int)pos.x + x, (int)pos.y + y] != null) {
					neighbors.Add (tiles [(int)pos.x + x, (int)pos.y + y]);
				}
			}
		}
		int matches = 0;
		foreach(Tile neighbor in neighbors){
			if (neighbor.color == color)
				matches++;
		}
		if(matches >= threshold)
			return true;
		else
			return false;
	}

	public bool inRange (Vector2 position){
		if (position.x > 0 && position.x < mapBounds.x && position.y > 0 && position.y < mapBounds.y)
			return true;
		else
			return false;
	}

	void Update (){
		if (Input.GetKeyDown (KeyCode.Space)) {
			foreach (Tile tile in tiles) {
				Destroy(tile.getGameObject());
			}
			tiles = new Tile[(int)mapBounds.x, (int)mapBounds.y];
			Generate ();
		}
	}
}
