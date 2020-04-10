using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* As we have selected Is Trigger, for the game object
     * to which the script is attached, via the Inspector,
     * the ball will not bounce back as opposed to a normal
     * collision sans trigger. */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the ball collides with the bottom wall, print GAME OVER.
        print("Game over!");
    }
}
