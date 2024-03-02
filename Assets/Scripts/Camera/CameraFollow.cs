using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraFollow : MonoBehaviour {
    private float turnSpeed = 8.0f;
    [SerializeField] private GameObject player;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float yOffset = 10.0f;
    [SerializeField] private float zOffset = -10.0f;

    //zoom variables
    private float minFov = 15f;
    private float maxFov = 90f;
    private float sensitivity = 10f;

    private void Start() {
        //get player transform
        playerTransform = player.transform;
        //set camera offset
        cameraOffset = new Vector3(playerTransform.position.x, playerTransform.position.y + yOffset, playerTransform.position.z + zOffset);
    }


    void FixedUpdate() {
        //follow player
        FollowPlayer();
        ZoomCamera();
        //if middle mouse button is pressed
        if (Input.GetMouseButton(2)) {
            //orbit player
            OrbitPlayer();
        }
    }

    private void OrbitPlayer() {
        //rotate camera offset around player
        cameraOffset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * cameraOffset;
        //set camera position to player position + camera offset
        transform.position = playerTransform.position + cameraOffset;
        //look at player
        transform.LookAt(playerTransform.position);
    }

    private void FollowPlayer() {
        //set camera position to player position + camera offset
        transform.position = playerTransform.position + cameraOffset;
    }

    private void ZoomCamera() {
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
    }
}
