using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dripper : MonoBehaviour {

	public GameObject obj;

	// Use this for initialization
	void Start () {
		if(startOnStart){
            dropping = true;
        }else{
            dropping = false;
        }
        InvokeRepeating("Drip", 0.2f, rate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float rate = 2f;

	bool dropping = true;

	public bool startOnStart = true;

	public void IsDropping(bool newDropping){
		dropping = newDropping;
	}

	public void Drip(){
		if(dropping) Instantiate(obj, transform.position, transform.rotation);
	}

	public void SetRate(float newRate){
		rate = newRate;
		CancelInvoke ();
		InvokeRepeating("Drip", 0.2f, newRate);
	}

}
