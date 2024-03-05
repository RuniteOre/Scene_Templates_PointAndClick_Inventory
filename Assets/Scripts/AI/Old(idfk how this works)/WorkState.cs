using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorkState : IEnemyState {
    public Transform tree;
    private readonly AICharacter ai;

    public WorkState(AICharacter aiCharacter) {
        ai = aiCharacter;
    }

    public void Enter() {
        ai.MoveTo(tree.position);
    }

    public void Execute() {
        if (ai.canMove) {
            //check
            ai.Check();
        }
    }

    public void Exit() {
        Debug.Log("Exiting Work State");
    }
}
