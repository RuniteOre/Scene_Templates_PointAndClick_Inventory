using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//farmer is the blue guy, he just goes to the tree, gets wood and walks it to his pile. if you walk into him he drops the wood and goes back to the tree
public class Farmer : MonoBehaviour {
    //references
    public Transform tree;
    public Transform woodPile;
    public GameObject player;
    public GameObject woodPrefab;
    public Transform itemSlot;
    public Rigidbody rb;

    //variables
    public float speed;
    public bool carryingWood = false;
    public bool canMove = true;

    public void Start() {
        //set rb to rigidbody
        rb = GetComponent<Rigidbody>();
        MoveTo(tree.position);
    }

    public void Update() {
            //if farmer can move
        if (canMove) {
            //check
            Check();
        }
    }

    public void MoveTo(Vector3 target) {
        //move towards target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //look at target
        transform.LookAt(target);
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

    private void DropWood() {
        //destroy wood
        Destroy(itemSlot.GetChild(0).gameObject);
        //set carrying wood to false
        carryingWood = false;
        Invoke("CanMove", 1f);
    }

    private void OnTriggerEnter(Collider other) {
    //if player walks into farmer
    //stop moving
    canMove = false;
            //drop wood
            //farmer jumps up and down to show he dropped the wood
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            DropWood();
    }

    private void CanMove() {
        //I know this is dumb but bear with me
        canMove = true;
    }
}
