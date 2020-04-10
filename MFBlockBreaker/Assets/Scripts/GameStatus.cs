using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//To be able to use TextMeshProUGUI.
using TMPro;

public class GameStatus : MonoBehaviour
{
    //By default, scores start from 0.
    [SerializeField] int currentScore = 0;
    //We will add 10 points for each block destroyed.
    [SerializeField] int pointsPerBlockDestroyed = 10;

    //The text control storing the text score.
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        /* Update the scoreText with the current score,
         * initially it is set to 0. 
         * Use the TextMeshProUGUI to update the score. */
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        //Update the score.
        scoreText.text = $"Score: {currentScore}";
    }

    public void AddToScore() 
    {
        //Add the score by 10 points.
        currentScore += pointsPerBlockDestroyed;
        //Update the score after points have been added.
        scoreText.text = $"Score: {currentScore}";
    }
}
