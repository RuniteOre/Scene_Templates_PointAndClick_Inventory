using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerFollowState : StalkerBaseState {
    public override void EnterState(StalkerStateManager stalker) {

    }
    public override void UpdateState(StalkerStateManager stalker) {
        //follow the player
        stalker.agent.SetDestination(stalker.player.transform.position);
    }
    public override void OnTriggerEnter(StalkerStateManager stalker) {
        //nothing
    }
    public override void OnTriggerExit(StalkerStateManager stalker) {
        stalker.SwitchState(stalker.idleState);
    }
    public override void OnCollisionEnter(StalkerStateManager stalker) {
        stalker.SwitchState(stalker.attackState);
    }
}
