using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    //By default, scores start from 0.
    [SerializeField] int currentScore = 0;
    //We will add 10 points for each block destroyed.
    [SerializeField] int pointsPerBlockDestroyed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore() 
    {
        //Add the score by 10 points.
        currentScore += pointsPerBlockDestroyed;
    }
}
