using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerAttackState : StalkerBaseState {
    public override void EnterState(StalkerStateManager stalker) {
        //nothing
    }
    public override void UpdateState(StalkerStateManager stalker) {
        stalker.TakeDamage();
    }
    public override void OnTriggerEnter(StalkerStateManager stalker) {
        //nothing
    }
    public override void OnTriggerExit(StalkerStateManager stalker) {
        //nothing
    }
    public override void OnCollisionEnter(StalkerStateManager stalker) {
    }//nothing
}
