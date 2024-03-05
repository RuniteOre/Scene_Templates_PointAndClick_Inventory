using UnityEngine;

public class FarmerFleeState : FarmerBaseState {
    private float fleeDuration = 3f;
    private float fleeTimer = 0f;
    private bool fleeing = false;

    public override void EnterState(FarmerStateManager farmer) {
        Debug.Log("fleeing");
        fleeing = true;
        fleeTimer = 0f;
    }

    public override void UpdateState(FarmerStateManager farmer) {
        if (fleeing) {
            fleeTimer += Time.deltaTime;
            if (fleeTimer >= fleeDuration) {
                farmer.MoveTo(farmer.woodPile.position);
                fleeing = false;
                farmer.SwitchState(farmer.WorkingState);
            }
        }
    }

    public override void OnCollisionEnter(FarmerStateManager farmer) {

    }

    public override void OnCollisionExit(FarmerStateManager farmer) {

    }
}
