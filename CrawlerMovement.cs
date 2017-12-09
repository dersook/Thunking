using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerMovement : MonoBehaviour {

	public float distance = Mathf.Infinity;
	public float angle = 0f;
	public GameObject tileMap;
	public float speed = 1f;

	// Use this for initialization
	void Start () {
		tileMap = GameObject.Find("TileMap");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
