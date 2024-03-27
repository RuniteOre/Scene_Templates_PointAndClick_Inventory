using UnityEngine;

public class FarmerWorkingState : FarmerBaseState {
    public override void EnterState(FarmerStateManager farmer) {
        Debug.Log("workin");
        farmer.MoveTo(farmer.tree.position);
    }

    public override void UpdateState(FarmerStateManager farmer) {
        farmer.Check();
    }

    public override void OnCollisionEnter(FarmerStateManager farmer) {
        //switch to surprised
        farmer.SwitchState(farmer.SurpriseState);
    }

    public override void OnCollisionExit(FarmerStateManager farmer) {
        //nothing
    }
}
