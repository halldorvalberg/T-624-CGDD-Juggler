using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreLabel;
    public TMPro.TextMeshProUGUI highScoreLabel;
    public TMPro.TextMeshProUGUI powerUpLabel;

    void Update() {
        scoreLabel.text = GameManager.instance.score.ToString();
        highScoreLabel.text = GameManager.instance.highScore.ToString();

        if (GameManager.instance.largerPaddle) {
            powerUpLabel.text = "Larger Paddle";
        }
        else if (GameManager.instance.smallerPaddle) {
            powerUpLabel.text = "Smaller Paddle";
        }
        else if (GameManager.instance.fasterPaddle) {
            powerUpLabel.text = "Faster Paddle";
        }
        else {
            powerUpLabel.text = "None";
        }
    }
}
