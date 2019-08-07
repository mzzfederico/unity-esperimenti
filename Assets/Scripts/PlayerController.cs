using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBodyComp;
    public GameObject gameInstance;
    public float speed;
    public bool isFrozen = false;

    void FixedUpdate() {
        if (!isFrozen) {
            UpdateMovement(speed);
        }
    }

    private void OnEnable() {
        rigidBodyComp = GetComponent<Rigidbody>();
        rigidBodyComp.isKinematic = true;
        rigidBodyComp.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Finish")) {
            gameInstance.SendMessage("victorySequence");
        }

        if (other.CompareTag("Points")) {
            other.gameObject.SetActive(false);
            gameInstance.SendMessage("addToPoints", 100);
        }

        if (other.CompareTag("Death"))
        {
            gameInstance.SendMessage("defeatSequence");
        }
    }

    void UpdateMovement(float extraForce) {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rigidBodyComp.AddForce(movement * extraForce);
    }

    void setIsFrozen (bool newState) {
        isFrozen = newState;
    }
}
