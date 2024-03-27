using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerIdleState : StalkerBaseState {
    public override void EnterState(StalkerStateManager stalker) {

    }
    public override void UpdateState(StalkerStateManager stalker) {
        //walk around navmesh randomly
        stalker.agent.SetDestination(stalker.GetRandomPoint());

    }
    public override void OnTriggerEnter(StalkerStateManager stalker) {
        stalker.SwitchState(stalker.followState);
    }
    public override void OnTriggerExit(StalkerStateManager stalker) {
        //nothing
    }
    public override void OnCollisionEnter(StalkerStateManager stalker) {
        //nothing
    }
}
