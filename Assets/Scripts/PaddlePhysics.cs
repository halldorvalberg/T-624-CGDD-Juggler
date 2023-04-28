using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePhysics : MonoBehaviour
{
    public float maxReflectAngle;

    public AudioSource paddleSound;
    public AudioSource powerUpSound;

    void OnTriggerEnter2D(Collider2D other) {
        Rigidbody2D ball = other.attachedRigidbody ;
        if (ball != null) {
            Vector2 paddleNormal = transform.up;
            // Don't bounce balls that enter from behind 
            float ballAngle = Vector2.Angle(paddleNormal, ball.velocity);
            if (ballAngle > 90) {
                // Refelct the ball's velocity abotu the paddle's normal to get the bounce velocity
                Vector2 reflectedVelocity = Vector2.Reflect(ball.velocity, paddleNormal);

                // Now we clamp the reflection angle to maxReflectAngle
                // We want the signed angle so we know which direction to rotate it 
                float reflectAngle = Vector2.SignedAngle(paddleNormal, reflectedVelocity);

                // check if the bounce is too shallow
                if (Mathf.Abs(reflectAngle) > maxReflectAngle) {
                    // Figure out how far past the maximum angle we are
                    float deltaAngle = (Mathf.Sign(reflectAngle) * maxReflectAngle) - reflectAngle;
                    // A quaternion represents a rotation, in this case about the z axis
                    Quaternion clampRotation = Quaternion.Euler(0, 0, deltaAngle);
                    // Multiply a vector by a quaternion gives you that vector rotated by the quaternion
                    reflectedVelocity = clampRotation * reflectedVelocity;    
                }

                // Update the score
                GameManager.instance.score++;

                if (GameManager.instance.score > GameManager.instance.highScore) {
                    GameManager.instance.highScore = GameManager.instance.score;
                }

                // if the game score is a modulo of 25 we call the RandomPowerUp function
                if (GameManager.instance.score % 5 == 0) {
                    GameManager.instance.RandomPowerUp();
                    powerUpSound.Play();
                }

                // play the sound
                paddleSound.Play();
                
                // We want the ball to go faster as the game goes on
                // We'll use a multiplier to increase the ball's speed
                // We'll use the score as a multiplier
                float ballSpeedMultiplier = (1.0f + (GameManager.instance.score * 0.0001f));

                // To make the ball go faster, we multiply the velocity by a multiplier
                // update the ball's velocity to bounce it away
                ball.velocity = reflectedVelocity;

            }
        }
    }
}
