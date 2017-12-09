using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine {

    private IState currentlyRunningState;

    private IState previousState;

    public void ChangeState(IState newState)
    {
        if (currentlyRunningState != null)
            this.currentlyRunningState.Exit();
        this.previousState = this.currentlyRunningState;

        this.currentlyRunningState = newState;
        this.currentlyRunningState.Enter();
    }

    public void ExecuteStateUpdate()
    {
        var runningState = this.currentlyRunningState;
        if(runningState != null)
            this.currentlyRunningState.Execute();
    }

    public void SwitchToPreviousState()
    {
        this.currentlyRunningState.Exit();
        this.currentlyRunningState = this.previousState;
        this.currentlyRunningState.Enter();
    }

    public void ExitCurrentState() {
        IState runningState = this.currentlyRunningState;
        if(runningState != null)
        this.currentlyRunningState.Exit();
    }

    public void OnTriggerEnter(Collider2D collision)
    {
        IState runningState = this.currentlyRunningState;
        if (runningState != null)
            this.currentlyRunningState.OnTriggerEnter(collision);
    }

    public void OnCollisionEnter(Collision2D collision)
    {
        IState runningState = this.currentlyRunningState;
        if (runningState != null)
            this.currentlyRunningState.OnCollisionEnter(collision);
    }
}
