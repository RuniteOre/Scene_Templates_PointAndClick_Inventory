using JetBrains.Annotations;
using UnityEngine;

public class CatIdleState : CatBaseState {
    public override void EnterState(CatStateManager cat) {
        
    }

    public override void UpdateState(CatStateManager cat) {

    }

    public override void OnTriggerEnter(CatStateManager cat) {
    }

    public override void OnTriggerExit(CatStateManager cat) {
        cat.SwitchState(cat.FollowState);
    }
}
