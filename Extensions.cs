using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Extensions
{
    public static bool near(this float one, float other, float threshold)
    {
        return Math.Abs(one - other) <= threshold;
    }
    public static float quantum(this float one, float other)
    {
        System.Random random = new System.Random();
        float add = (float) random.Next(0, 100) / 100 * Math.Abs( one - other );
        return one + add;
    }
    public static bool beat(this int num)
    {
        return num == 1;
    }
    public static bool beat(this float num)
    {
        return num == 1;
    }
    public static bool isGrounded(this GameObject gameObject){
        return Physics.Raycast(gameObject.transform.position, -Vector3.up, gameObject.GetComponent<Collider2D>().bounds.extents.y + 0.1f);
    }
    public static bool noGap(this GameObject gameObject, float direction){
        return Physics.Raycast((Vector2) gameObject.transform.position + new Vector2(direction, 0), 
        -Vector2.up, gameObject.GetComponent<Collider2D>().bounds.extents.y + 1f);
    }
    public static float x(this GameObject gameObject){
        return gameObject.transform.position.x;
    }
    public static float y(this GameObject gameObject){
        return gameObject.transform.position.x;
    }
    public static Vector2 position(this GameObject gameObject){
        return gameObject.transform.position;
    }
    public static float getDirection(this GameObject gameObject){
        return gameObject.transform.rotation.y > 90f ? 1 : -1;
    }
    public static float getDirection(this Transform trans){
        return trans.localRotation.y > 90f ? 1 : -1;
    }
    public static void setDirection(this GameObject gameObject, int arg){
        gameObject.transform.localRotation = Quaternion.Euler(0.0f, arg > -1 ? 0.0f : 180.0f, 0.0f);
    }

    public static int determineDirectionX(this Transform obj, Transform player, float closest, float farthest){
        int result = 1;
        if(player.position.x < obj.position.x)
            result = -1;
        if( Math.Abs(obj.position.x - player.position.x) < closest )
            result *= -1;
        else if( Math.Abs(obj.position.x - player.position.x) > farthest )
            result *= 1;
        else
            result = 0;
        return result;
    }
    public static bool inRangeX(this Transform obj, Transform player, float closest, float farthest){
        float distance = Math.Abs(obj.position.x - player.position.x);
        return ( (distance > closest) && (distance < farthest) );
    }
    static int frameBeat = 0;
    public static void incrementRhythm(){
        frameBeat++;
        if(frameBeat > 1000000) frameBeat = 0;
    }
    public static bool rhyme(int arg){
        return frameBeat % arg == 0;
    }
    public static bool rhyme(int arg, int offset){
        return frameBeat % arg == offset;
    }
    public static float normalize(this int arg){
        if(arg == 0) return 0;
        return arg > 0 ? 1f : -1f;
    }
    public static float normalize(this float arg){
        if(arg == 0f) return 0f;
        return arg > 0f ? 1f : -1f;
    }
    public static void InvokeA(this MonoBehaviour me, Action theDelegate, float time)
    {
        me.StartCoroutine(ExecuteAfterTime(theDelegate, time));
    }
    private static IEnumerator ExecuteAfterTime(Action theDelegate, float delay)
    {
        yield return new WaitForSeconds(delay);
        theDelegate();
    }
    public static float forward(this int arg, Transform transform){
        return arg * transform.right.x;
    }
    public static float forward(this float arg, Transform transform){
        return arg * transform.right.x;
    }
}

