using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    
    public GameObject gameOverScreen;
  
    public bool gameOver = false;

    private int mooCounter = 60;
    
    // audio files
    public AudioSource mooSound;
    public AudioSource gameOverSound;



    public FirstBallController ballController;

    // function for the game over screen
    public void GameOver() {
        
        // Show the game over screen
        gameOverScreen.SetActive(true);
        // Set the game over variable to true
        gameOver = true;
    }

    public void RandomPowerUp() {
        // then we randomly choose one of the power ups
    

        int randomPowerUp = Random.Range(0, 3);

        // print the random power up
        print(randomPowerUp);

        if (randomPowerUp == 0) {
            if (!largerPaddle) {            
                resetPowerUps();
                LargerPaddle();
            }
            else {
                resetPowerUps();
            }

        }
        else if (randomPowerUp == 1) {
            if (!smallerPaddle) {
                resetPowerUps();
                SmallerPaddle();
            }
            else {
                resetPowerUps();
            }
        }
        else if (randomPowerUp == 2) {
            if (!fasterPaddle) {
                resetPowerUps();
                FasterPaddle();
            }
            else {
                resetPowerUps();
            }
        }
        else if (randomPowerUp == 3) {
            if (!slowerPaddle) {
                resetPowerUps();
                SlowerPaddle();
            }
            else {
                resetPowerUps();
            }
        }
        else {
            resetPowerUps();
        }
    }

    public void resetPowerUps() {
        largerPaddle = false;
        smallerPaddle = false;
        fasterPaddle = false;
        slowerPaddle = false;
    }

    // all we need for larger paddle powerup
    public bool largerPaddle = false;
    public void LargerPaddle() {
        // in this function we will make the paddle larger
        largerPaddle = true;
    }

    // all we need for smaller paddle powerup
    public bool smallerPaddle = false;
    public void SmallerPaddle() {
        // in this function we will make the paddle smaller
        smallerPaddle = true;
    }

    // Speed up the paddle
    public bool fasterPaddle = false;
    public void FasterPaddle() {
        fasterPaddle = true;
    }

    // Slow down the paddle
    public bool slowerPaddle = false;
    public void SlowerPaddle() {
        slowerPaddle = true;
    }

    public void Update() {
        mooCounter--;
        if (mooCounter == 0) {
            mooSound.Play();
            mooCounter = 600;
        }

        if (gameOver) {
                // Play the game over sound
                gameOverSound.Play();
                // Play the moo sound
                mooSound.Play();
                

            if (Input.GetMouseButton(0)) {
                // Reset the score
                GameManager.instance.score = 0;
                // Display the game over screen
                gameOverScreen.SetActive(false);
                gameOver = false;
                // Reset the ball and paddle 
                ballController.Reset();
                resetPowerUps();

            }
        }   

    }

    public int score;
    public int highScore;

    void Awake() {
        instance = this;
    }
    
}
