using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour {
    public Transform target;
    public float smoothSpeed = 2f;
    public Vector3 offset;

    private void LateUpdate() {
        if (PlayerController.playerIsAlive) {
            Vector3 newPosition = target.position;
            newPosition.z = -10;
            transform.position = Vector3.Slerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
