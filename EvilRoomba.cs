using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EvilRoomba : MonoBehaviour {

        public Vector2[] points;
        Vector2 target;
        public float speed = 3f;
        private int destPoint = 1;
        void Start () {
			if (points.Length == 0)
                return;
			for(int i = 0; i < points.Length; i++){
				points[i] = points[i] + (Vector2) transform.position;
            }
            transform.position = points[0];
            
			target = points[destPoint];

        }
        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + ((Vector2) target - (Vector2) transform.position).normalized * Time.fixedDeltaTime * speed);
            if((target - GetComponent<Rigidbody2D>().position).magnitude < 0.05){
                destPoint = (destPoint + 1) % points.Length;
                target = points[destPoint];
            }
        }
    }
