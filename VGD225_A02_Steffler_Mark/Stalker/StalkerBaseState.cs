using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StalkerBaseState {
    public abstract void EnterState(StalkerStateManager stalker);
    public abstract void UpdateState(StalkerStateManager stalker);
    public abstract void OnTriggerEnter(StalkerStateManager stalker);
    public abstract void OnTriggerExit(StalkerStateManager stalker);

    public abstract void OnCollisionEnter(StalkerStateManager stalker);
}
