using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//To be able to access the classes related to scene management in Unity.
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    /* As we have selected Is Trigger, for the game object
     * to which the script is attached, via the Inspector,
     * the ball will not bounce back as opposed to a normal
     * collision sans trigger. */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the ball collides with the bottom wall, print GAME OVER.
        print("Game over!");

        /* Change scene to Lose Scene to let user know that because 
         * the ball has collided with the bottom wall, 
         * the game stops and the user loses the game. */
        SceneManager.LoadScene("LoseScene");
    }
}
