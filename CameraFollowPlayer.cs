using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    private GameObject playerCharacter;

    // Use this for initialization
    void Start () {
        playerCharacter = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(playerCharacter.transform.position.x, playerCharacter.transform.position.y, transform.position.z);
	}

    void FixedUpdate() {
        Extensions.incrementRhythm();
    }
}
