using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFollowingPlayer : MonoBehaviour {

    public Vector3 offset;
    private GameObject player;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = player.transform.position + offset;
	}
}
