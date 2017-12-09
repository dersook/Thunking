using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState{

    string GetName();

    void Enter();

    void Execute();

    void Exit();

    void OnTriggerEnter(Collider2D collider);

    void OnCollisionEnter(Collision2D collision);

}
