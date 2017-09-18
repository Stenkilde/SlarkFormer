using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    // Movement
    public float movespeed;
    public float jump;
    private float moveVelocity;

    // Economy
    public GUIText goldValue;
    public int goldScore;

    // Grounded
    bool grounded = true;

    // Update is called once per frame
    void Update()
    {
        goldScore = 0;
        UpdateScore();

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }

        moveVelocity = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = -movespeed;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity = movespeed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Lava")
        {
            Destroy(gameObject);
        }
    }

    // Check if Grounded
    void OnTriggerEnter2D()
    {
        grounded = true;
    }

    void OnTriggerExit2D()
    {
        grounded = false;
    }

    void UpdateScore()
    {
        goldValue.text = "Gold: " + goldScore;
    }

    public void AddScore(int newScoreValue)
    {
        goldScore += newScoreValue;
        UpdateScore();
    }
}