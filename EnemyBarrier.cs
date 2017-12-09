using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrier : MonoBehaviour {

	public Vector2Int rightBottom = new Vector2Int(1, 1);
	public GameObject[] dependencies;
	public GameObject obj;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < rightBottom.x; i++)
			for(int j = 0; j < rightBottom.y; j++){
				GameObject go = Instantiate(obj, transform);
				go.transform.position = (Vector2) transform.position + new Vector2(i, j);
			}
	}
	
	// Update is called once per frame
	void Update () {

		//Do this last
		foreach(GameObject a in dependencies){
			if(a != null) return;
		}
		Destroy(gameObject, 1.0f);
	}
}
