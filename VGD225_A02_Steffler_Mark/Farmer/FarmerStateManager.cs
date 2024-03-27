using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;

public class FarmerStateManager : MonoBehaviour {
    FarmerBaseState currentState;
    public FarmerWorkingState WorkingState = new FarmerWorkingState();
    public FarmerSurpriseState SurpriseState = new FarmerSurpriseState();
    public FarmerFleeState FleeState = new FarmerFleeState();

    //references
    public Transform tree;
    public Transform woodPile;
    public GameObject player;
    public GameObject woodPrefab;
    public Transform itemSlot;

    //vars
    public float speed;
    public bool carryingWood = false;

    // Start is called before the first frame update
    void Start() {
        //starting state for the machine
        currentState = WorkingState;
        //enter the starting state for THIS script
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update() {
        //update every tick for all states when it's in the right state
        currentState.UpdateState(this);
    }

    public void SwitchState(FarmerBaseState state) {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnCollisionEnter(Collision collision) {
        //if it's with the player
        if (collision.gameObject.CompareTag("Player")) {
            //switch to surprised
            SwitchState(SurpriseState);
        }
    }

    private void OnCollisionExit(Collision collision) {

    }

    //funcs
    public void MoveTo(Vector3 target) {
        // Calculate the direction to the target
        Vector3 direction = (target - transform.position).normalized;

        // Move the farmer towards the target
        transform.position += direction * speed * Time.deltaTime;

        // Update the rotation only on the y-axis to look towards the target
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
    }


    public void Check() {
        //calculate distance between farmer and player
        float distanceToTarget;

        //if farmer is carrying wood
        if (carryingWood) {
            //move to wood pile
            MoveTo(woodPile.position);
            //calculate distance between farmer and wood pile
            distanceToTarget = Vector3.Distance(transform.position, woodPile.position);
            //if farmer is at the wood pile, drop the wood
            if (distanceToTarget < 2f) {
                DropWood();
            }
        }
        else {
            //move to tree
            MoveTo(tree.position);
            //calculate distance between farmer and tree
            distanceToTarget = Vector3.Distance(transform.position, tree.position);
            //if farmers at the tree, get the wood
            if (distanceToTarget < 3f && !carryingWood) {
                GetWood();
            }
        }
    }

    private void GetWood() {
        //instantiate wood at itemSlot as child
        GameObject wood = Instantiate(woodPrefab, itemSlot);
        //set wood position to itemSlot position
        wood.transform.position = itemSlot.position;
        //set carrying wood to true
        carryingWood = true;
    }

    public void DropWood() {
        //destroy wood
        Destroy(itemSlot.GetChild(0).gameObject);
        //set carrying wood to false
        carryingWood = false;
    }

}
