using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimationStateCheck : StateMachineBehaviour {

	public GameObject player;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		player = GameObject.Find ("Player");
		if (player == null) {
			Debug.Log ("Player Object does not exist.");
		}
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (player.GetComponent<Status> ().health < 1)
			
			player.gameObject.SetActive (false);
	}
		
}
