using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour{
    public int health = 5;
    public int maxHealth = 5;
    public bool isBusy = false;
    public bool isInvincible = false;
    public bool isStunned { get {return stunFrames > 0;} }
    public bool isEvading = false;
    public bool isDead { get {return health <= 0;} }
    public bool isDying = false;
    public float direction = 1;
    public GameObject mostRecentTrigger;
    public void stun(int frames){
        stunFrames = frames;
    }
    public void Start(){
        health = maxHealth;
    }
    public void Update(){
        
    }
    public int stunFrames = 0;
    public void FixedUpdate(){
        direction = gameObject.getDirection();
        if(isDying) return;
        if(isDead){
            isDying = true;
            gameObject.layer = 9;
            Destroy(gameObject, 0.5f);
            return;
        }
        stunFrames -= 1;
        if (stunFrames < 0) stunFrames = 0;
    }
    public void TakeAttack(AttackProperties attackProperties){
        if(!isStunned){
            health -= attackProperties.attackDamage;
            if(health < 0) {
                health = 0;
            }
        }
    }
}
