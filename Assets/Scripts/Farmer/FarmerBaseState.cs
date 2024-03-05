using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FarmerBaseState {
    public abstract void EnterState(FarmerStateManager farmer);
    public abstract void UpdateState(FarmerStateManager farmer);
    public abstract void OnCollisionEnter(FarmerStateManager farmer);
    public abstract void OnCollisionExit(FarmerStateManager farmer);
}
