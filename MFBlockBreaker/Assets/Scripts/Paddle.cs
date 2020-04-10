using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //This method runs only once when the game launches.
    void Start()
    {
        
    }

    /* Update runs continuously per frame. 
     * If the game is running at 60 frames per second, 
     * this function runs 60 times per second. */
    void Update()
    {
        //Determine the position of the mouse to track movement.
        print(Input.mousePosition);
    }
}
