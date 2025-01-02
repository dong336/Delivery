using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 5f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float slowSpeed = 1f;
    [SerializeField] float bootSpeed = 2f;

    void Update() {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (moveSpeed < 2f) return;

        moveSpeed -= slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost") {
            moveSpeed += bootSpeed;
        }
    }
}
