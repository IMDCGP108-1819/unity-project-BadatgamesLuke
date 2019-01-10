using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float thrust;
    public float turnThrust;
    private float thrustInput;
    private float turnInput;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    public float bulletForce;
    public float killedby;

    public int score1;
    public int numberoflives;

    public Text scoreText;
    public Text livesText;

    public GameObject bullet;

    // Use this for initialization
    void Start() {
        score1 = 0;

        scoreText.text = "Score " + score1;
        livesText.text = "Lives " + numberoflives;
    }

    // Update is called once per frame
    void Update()
    {
        //Gets input from the keyboard and apply thrust
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        //Code Checks for input from the fire key and makes bullets
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletForce);
            Destroy(newBullet, 5.0f);
        }
        transform.Rotate(Vector3.forward * turnInput * Time.deltaTime * -turnThrust);

        //ScreenWraping
        Vector2 newPos = transform.position;
        if (transform.position.y > screenTop)
        {
            newPos.y = screenBottom;
        }
        if (transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }

        if (transform.position.x < screenRight)
        {
            newPos.x = screenLeft;
        }
        if (transform.position.x > screenLeft)
        {
            newPos.x = screenRight;
        }

        transform.position = newPos;


    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * thrustInput);
    }
    void ScorePoints(int pointsToAdd)
    {
        score1 += pointsToAdd;
        scoreText.text = "Score " + score1;
    }
    //rb.AddTorque(-turnInput);

    // Code tells face hits Asteroid
    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.relativeVelocity.magnitude > killedby)
        {
            numberoflives--;
            livesText.text = "Lives " + numberoflives;

            if (numberoflives <= 0) {
            }
        }
    }
}