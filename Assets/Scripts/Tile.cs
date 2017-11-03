using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

	private GameObject gameObject;
	public Color color;
	private Vector2 position;

	public Tile(GameObject _gameObject, Color _color, Vector2 _position){
		gameObject = _gameObject;
		color = _color;
		position = _position;

		gameObject.GetComponent<SpriteRenderer> ().color = color;
	}

	public void setColor(Color _color){
		color = _color;
		gameObject.GetComponent<SpriteRenderer> ().color = _color;
	}

	public GameObject getGameObject(){
		return gameObject;
	}

	public Vector2 getPosition(){
		return position;
	}

}
