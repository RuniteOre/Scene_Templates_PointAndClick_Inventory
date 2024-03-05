using UnityEngine;

public class FarmerSurpriseState : FarmerBaseState {
    public override void EnterState(FarmerStateManager farmer) {
        farmer.DropWood();
        farmer.SwitchState(farmer.FleeState);
    }

    public override void UpdateState(FarmerStateManager farmer) {
        
    }

    public override void OnCollisionEnter(FarmerStateManager farmer) {
        
    }

    public override void OnCollisionExit(FarmerStateManager farmer) {
        
    }
}
