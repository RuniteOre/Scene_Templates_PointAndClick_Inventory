using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("Spot Clicked");

            if(Physics.Raycast(ray, out hit)) {
                agent.SetDestination(hit.point);
                Debug.Log("Moved");
            }
            if(hit.collider.gameObject.tag == "Tree") {
                agent.SetDestination(target.transform.position);
                target = hit.collider.gameObject;
                Debug.Log("Chopping Tree");
            }
        }
    }
}
