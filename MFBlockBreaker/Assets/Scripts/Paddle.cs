using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    /* 16 is the world unit in which the mouse is (the camera is 16 units wide.) 
     * You can find this out by hovering over to the far right side of the screen. */
    [SerializeField] float screenWidthInUnits = 16f;
    //SerializeField displays variables in the Unity Editor, the values can change as well.

    //Values to limit the paddle movement.
    [SerializeField] float minimumX = 1f;
    [SerializeField] float minimumY = 15f;

    //This method runs only once when the game launches.
    void Start()
    {
        //Determine the position of the mouse to track movement.

        //Get both x and y position of the mouse.
        print(Input.mousePosition);

        //Get the x and y position individually.
        print($"x: {Input.mousePosition.x} y: {Input.mousePosition.y}");
    }

    /* Update runs continuously per frame. 
     * If the game is running at 60 frames per second, 
     * this function runs 60 times per second. */
    void Update()
    {
        /* For the width of the screen, we get the x (horizontal) position of the mouse. 
         * Input.mousePosition.x / Screen.width shall give us a value between 0 and 1. */

        //width of screen in pixels (px)
        float horizontalMousePosition = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        //Move the paddle horizontally (of course, by using the x-axis)
        Vector2 paddlePosition = new Vector2(horizontalMousePosition, transform.position.y); //x and y

        /* transform.position.x - current x position
         * transform.position.y - current y position */

        /* transform.position changes the position of the game object. 
         * It's as though you're changing the positions from Transform in Unity Editor. */
        transform.position = paddlePosition;
    }
}
