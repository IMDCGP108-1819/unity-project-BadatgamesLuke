using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidM : MonoBehaviour {

    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    public int asteroidChange;
    public GameObject asteroidMedium;
    public GameObject asteroidSmall;
    public int points;
    public GameObject player;
    public GameObject boom;

    // Use this for initialization
    void Start() {
        //Code Adds movement and thrust to asteroids
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);

        //Find the player
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
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
    //Collisions between Asteroids and Beams
    void OnTriggerEnter2D(Collider2D other)

    {
        //Checks if a object in the game is a bullet
        if (other.CompareTag("beam")) {

            Destroy(other.gameObject);
            if (asteroidChange == 3) {
                Instantiate(asteroidMedium, transform.position, transform.rotation);
                Instantiate(asteroidMedium, transform.position, transform.rotation);
              
               
            }
            else if (asteroidChange == 2) {
                Instantiate(asteroidSmall, transform.position, transform.rotation);
                Instantiate(asteroidSmall, transform.position, transform.rotation);
            }
            else if (asteroidChange == 1) {

            }
            //Tells player that they need to score points
            player.SendMessage("ScorePoints",points);

            GameObject newBoom = Instantiate(boom, transform.position, transform.rotation);
            Destroy (newBoom, 3f);

            //Debug.Log("Hit" + other.name);
              Destroy(gameObject);
        } 
    }
}