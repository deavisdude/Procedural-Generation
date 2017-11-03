using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public GameObject hutPrefab;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			SpawnHut ();
		}
	}

	GameObject SpawnHut(){
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		float x = Mathf.Round (mousePos.x);
		float y = Mathf.Round (mousePos.y);
		Tile[,] tiles = MapGen.GetTiles ();
		Tile tile = tiles [(int)x, (int)y];

		if (tile.hut == null && tile.color != Color.blue) {
			GameObject hut = Instantiate (hutPrefab, new Vector3 (x, y, 0), hutPrefab.transform.rotation);
			tile.hut = hut;
			return hut;
		} else
			return null;
	}
}
