using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SurprisedState : IEnemyState {
    private readonly AICharacter ai;

    public SurprisedState(AICharacter ai) {
        this.ai = ai;
    }

    public void Enter() {
        ai.canMove = false;
        //drop wood
        //farmer jumps up and down to show he dropped the wood
        ai.rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        ai.DropWood();
        ai.ChangeState(new WorkState(ai));
        }

    public void Execute() {
    }

    public void Exit() {
    }
}
