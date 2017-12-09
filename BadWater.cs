using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadWater : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Terminate(){
		GameObject.Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag.Equals("Player")){
            GameObject.Destroy(collision.gameObject);
            //Destroy Animation
            collision.GetComponent<Status>().health = 0;

        }
		
	}

}
