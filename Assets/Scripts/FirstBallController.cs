using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBallController: MonoBehaviour {
    public Rigidbody2D body;
    public Vector2 direction;
    public float impulse;
    public Vector2 levelBounds;
    
    Vector2 startPosition;

    void Start() {
        startPosition = transform.position;

        // Reset so the starting impulse is applied
        Reset();
    }

    void Update() {
        // Only reset if the ball is leaving the play area and is out of the level bounds float ballAngle
        float ballAngle = Vector2.Angle(transform.position, body.velocity);
        if (ballAngle< 90 &&
            (transform.position.x < -levelBounds.x ||
            transform.position.x > levelBounds.x ||
            transform.position.y <-levelBounds.y ||
            transform.position.y > levelBounds.y))
        {
            GameManager.instance.GameOver();
        }
    }

    public void Reset() {
        transform.position = startPosition;
        body.velocity = direction.normalized * impulse;
        // Reset the score
        GameManager.instance.score = 0;
    }
}