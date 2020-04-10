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

    //The Awake method runs before Start.
    private void Awake()
    {
        /* As the score resets everytime the scene changes
         * when we intend the score to update from one scene
         * to the next, we will use Singleton Patterns. 
         * We will find all objects of GameStatus
         * and we will leave only one object running 
         * which is the first one! */

        //Find the amount of GameStatus objects in the project.
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        //What happens if there is more than one GameStatus object?
        if (gameStatusCount > 1)
        {
            //Disable and destroy the last game object.
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            //Else if there is only one GameStatus object, keep it.
            DontDestroyOnLoad(gameObject);

            /* If you run the game and win Level 1, 
             * you will see that when Level 2 loads, 
             * the current score in GameStatus is not reset
             * but instead remains the same as when it was saved in Level 1. */
        }
    }

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
