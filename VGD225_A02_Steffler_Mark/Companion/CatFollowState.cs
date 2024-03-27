using UnityEngine;

public class CatFollowState : CatBaseState {
    public Vector3 offset = new Vector3(1f, 0, 1f);
    public override void EnterState(CatStateManager cat) {

    }

    public override void UpdateState(CatStateManager cat) {
        //follow the player
        cat.transform.position = Vector3.MoveTowards(cat.transform.position, cat.player.transform.position + offset, cat.speed * Time.deltaTime);
        //look at the player
        cat.transform.LookAt(cat.player.transform);
        //add 90 to x axis
        cat.transform.Rotate(90, 0, 0);
    }

    public override void OnTriggerExit(CatStateManager cat) {
    }

    public override void OnTriggerEnter(CatStateManager cat) {
        cat.SwitchState(cat.IdleState);
    }
}
