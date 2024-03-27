using UnityEngine;

public abstract class CatBaseState {
    public abstract void EnterState(CatStateManager cat);
    public abstract void UpdateState(CatStateManager cat);
    public abstract void OnTriggerEnter(CatStateManager cat);
    public abstract void OnTriggerExit(CatStateManager cat);
}
