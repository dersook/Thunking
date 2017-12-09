using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFloor : MonoBehaviour {

	// Use this for initialization
	List<GameObject> fireBlocks = new List<GameObject>();
	public List<Vector2> pattern = new List<Vector2>();
	public GameObject fireBlock;
	public int amount = 1;
	IEnumerator Start () {
		for(int i = 0; i < amount; i++){
			GameObject gb = Instantiate(fireBlock, transform);
			gb.transform.position = new Vector2(transform.position.x + i, transform.position.y);
			fireBlocks.Add(gb);
		}
		while(true){
			foreach(Vector2 beat in pattern){
				yield return StartCoroutine(LightUp(beat.x, beat.y));
				yield return StartCoroutine(LightDown());
			}
		}
	}
	IEnumerator LightUp(float delay, float time){
        var i= 0.0f;
        var rate= 1.0f/0.4f;
		Vector2 startPos = transform.position;
		yield return new WaitForSeconds(delay);
		while (i < 1.0f) {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, startPos + new Vector2(0, 1), i);
            yield return null;
        }
		yield return new WaitForSeconds(time);
    }

	IEnumerator LightDown(){
        var i= 0.0f;
        var rate= 1.0f/0.4f;
		Vector2 startPos = transform.position;
		while (i < 1.0f) {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPos, startPos - new Vector2(0, 1), i);
            yield return null;
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
