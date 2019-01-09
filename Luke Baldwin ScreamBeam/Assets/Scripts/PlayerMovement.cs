using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public float thrust;
    public float turnThrust;
    private float thrustInput;
    private float turnInput;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //Gets input from the keyboard and apply thrust
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        //ScreenWraping
        Vector2 newPos = transform.position;
        if (transform.position.y > screenTop) {
            newPos.y = screenBottom;
        }
        if (transform.position.y < screenBottom) {
            newPos.y = screenTop;
        }

        if (transform.position.x < screenRight) { 
            newPos.x = screenLeft;
        }
        if (transform.position.x > screenLeft) { 
            newPos.x = screenRight;
        }

        transform.position = newPos;

    
}

    private void FixedUpdate()
    {
     rb.AddRelativeForce (Vector2.up * thrustInput);
        rb.AddTorque(-turnInput);
    }
}
