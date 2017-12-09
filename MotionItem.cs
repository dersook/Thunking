using UnityEngine;
using System;
public class MotionItem {
    public Vector2 destination; public float delay; public float time; public Action callback; public bool rotate = false; public Vector2 axis = new Vector2(0, 0); public float rotation = 0f;
    public MotionItem(Vector2 destination, float delay, float time, Action callback){
        this.destination = destination; this.delay = delay; this.time = time; this.callback = callback;
    }
    public MotionItem(Vector2 destination, float delay, float time){
        this.destination = destination; this.delay = delay; this.time = time; callback = ()=>{};
    }
    public MotionItem(float rotation, Vector2 axis, float delay, float time, Action callback){
        this.axis = axis; this.rotation = rotation; this.delay = delay; this.time = time; this.rotate = true; this.callback = callback;
    }
    public MotionItem(float rotation, Vector2 axis, float delay, float time){
        this.axis = axis; this.rotation = rotation; this.delay = delay; this.time = time; rotate = true; callback = ()=>{};
    }
}