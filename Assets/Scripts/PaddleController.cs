using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    // We define a public float variable called "roatationSpeed"
    public float rotationSpeed; 

    // We define a private bool variable called "wantsToRotate"
    bool wantsToRotate; 

    // We define a new function called FixedUpdate

    void FixedUpdate() {
        // We check if wantsToRotate is true
        if (wantsToRotate) {
            // If it is, we rotate the paddle by rotationSpeed
            transform.Rotate(0, 0, rotationSpeed* Time.fixedDeltaTime);
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            wantsToRotate = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            wantsToRotate = false;
        }
 

        if (GameManager.instance.largerPaddle)
        {
            transform.localScale = new Vector3(2, 1, 1);
        } 
        else if (GameManager.instance.smallerPaddle) 
        {
            transform.localScale = new Vector3(0.5f, 1, 1);
        } 
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // If fasterPaddle is true, then we will make the paddle faster
        if (GameManager.instance.fasterPaddle) {
            rotationSpeed = 180*2;
        }
        else if (GameManager.instance.slowerPaddle) {
            rotationSpeed = 180/2;
        }
        else {
            rotationSpeed = 180;
        }
    }

}
