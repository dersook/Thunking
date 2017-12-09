using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextCamera : MonoBehaviour {
	public Vector2 expanse = new Vector2(1, 1);
	public Vector2 cameraPosition = new Vector2(0, 0);
	public bool basedOnVariable = false;
	public float size = 7;
	public Bounds bounds;
	GameObject player;
	GameObject camera;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		camera = GameObject.Find("Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if(bounds.Contains((Vector2) player.transform.position)){
			if(basedOnVariable)
				camera.transform.position = cameraPosition;
			else
				camera.transform.position = bounds.center;
			camera.GetComponent<Camera>().orthographicSize = size;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject == player){
			Camera[] objs = Camera.allCameras;
			foreach(Camera c in objs)
				c.enabled = false;
			GetComponent<Camera>().enabled = true;
		}
	}
}
