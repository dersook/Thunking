using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSphere_Jumper : MonoBehaviour {
	CircleCollider2D collider;
	// Use this for initialization
	IEnumerator Start () {
		collider = GetComponent<CircleCollider2D>();
		yield return StartCoroutine(Grow());
	}
	void FixedUpdate() {

	}
	IEnumerator Grow(){
        var i= 0.0f;
        var rate= 1.0f/1.5f;
		Vector3 startRadius = transform.localScale;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			transform.localScale = startRadius * Mathf.Lerp(1f, 20f, i);
			yield return null;
		}
    }
	// Update is called once per frame
	void Update () {
		
	}
}
