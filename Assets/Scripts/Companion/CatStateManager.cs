using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStateManager : MonoBehaviour {
    CatBaseState currentState;
    public CatIdleState IdleState = new CatIdleState();
    public CatFollowState FollowState = new CatFollowState();

    public GameObject player;
    public float speed = 3f;
    
    // Start is called before the first frame update
    void Start() {
        //starting state for the machine
        currentState = IdleState;
        //enter the starting state for THIS script
        currentState.EnterState(this);
    }
    
    // Update is called once per frame
    void Update() {
        //update every tick for all states when it's in the right state
        currentState.UpdateState(this);
    }

    public void SwitchState(CatBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            currentState.OnTriggerEnter(this);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            currentState.OnTriggerExit(this);
        }
    }

    public void MoveTo(Vector3 target) {
        // Calculate the direction to the target
        Vector3 direction = (target - transform.position).normalized;

        // Move the farmer towards the target
        transform.position += direction * speed * Time.deltaTime;

        // Update the rotation only on the y-axis to look towards the target
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
    }
}
