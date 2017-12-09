using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomperMovement : MonoBehaviour {
    public enum State
    {
        Jumping,
        Falling,
        Grounded,
        Winding,
        Attacking
    }
    bool dropping = false;
    GameObject player;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Status status;
    private Collider2D collider2d;
    public State state;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
    }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
        status = GetComponent<Status>();
    }

    Vector2 CalculateJumpVelocity(Vector2 target)
    {
        Vector2 dir = target - (Vector2) transform.position;
        float h = dir.y;
        dir.y = 0;
        float dist = dir.magnitude;
        dir.y = dist;
        dist += h;
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / 2);
        return vel * dir.normalized;
    }

    public void JumpToTarget(Vector2 target)
    {
        rb2d.velocity = CalculateJumpVelocity(target);
    }

    // Update is called once per frame
    void Update()
    {
        State oldState = state;
        if (rb2d.velocity.y > 0) state = State.Jumping;
        if (rb2d.velocity.y < 0) state = State.Falling;
        if (rb2d.velocity.y == 0){
            state = State.Grounded; dropping = false;
        }
    }

    

    //public Dictionary<Tuple<>, Action> transitionReactions = new Dictionary<Tuple, Action>();

    //private class Pair<T1, T2>
    //{
    //    T1 item1; T2 item2;
    //    public Pair<T1, T2>(T1 item1, T2 item2){
            
    //    }
    //}

    //public void AddStateTransitionReaction(State oldState, State newState, Action action)
    //{

    //}

    //private void FixedUpdate()
    //{
    //    if (state != State.Grounded )
    //        if (transform.position.x.near(player.transform.position.x, 0.25f) && !dropping)
    //        {
    //            state = State.Falling;
    //            rb2d.velocity = new Vector2(0, 0);
    //            rb2d.AddForce(new Vector2(0, -5), ForceMode2D.Impulse);
    //            dropping = true;
    //        }
    //}
}
