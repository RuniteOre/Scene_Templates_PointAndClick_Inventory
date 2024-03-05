using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StalkerStateManager : MonoBehaviour {
    StalkerBaseState currentState;
    public StalkerIdleState idleState = new StalkerIdleState();
    public StalkerFollowState followState = new StalkerFollowState();
    public StalkerAttackState attackState = new StalkerAttackState();

    //refs
    public GameObject player;
    public float speed = 2.0f;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start() {
        currentState = idleState;
        //enter the starting state for THIS script
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update() {
        //update every tick for all states when it's in the right state
        currentState.UpdateState(this);
    }

    public void SwitchState(StalkerBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            SwitchState(followState);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            SwitchState(idleState);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            SwitchState(attackState);
        }
    }

    public void TakeDamage() {
        Debug.Log("Taking Damage");
        //spin around
        transform.Rotate(0, 180, 0);
    }

    public Vector3 GetRandomPoint() {
        Vector3 randomDirection = Random.insideUnitSphere * 10;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 10, 1);
        return hit.position;
    }
}
