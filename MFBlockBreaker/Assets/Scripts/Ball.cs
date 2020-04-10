using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Creating a Paddle object to connect the ball to the paddle.
    [SerializeField] Paddle paddle;

    //Will contain the value of distance between the ball and paddle.
    Vector2 paddleToBallDistance;

    //Determine whether or not the ball has started moving.
    bool hasStarted = false; //false - not moving

    //Horizontal and vertical positions to add velocity to give the ball force upwards.
    [SerializeField] float xPosition = 2f;
    [SerializeField] float yPosition = 15f;
    
    /* Store multiple sound effects for the ball.
     * A random one will play upon the ball colliding with another object. */
    [SerializeField] AudioClip[] ballSounds;

    void Start()
    {
        /* Calculate the distance between the ball and paddle. 
         * Note that this.transform.position can be simplified to transform.position. */
        paddleToBallDistance = this.transform.position - paddle.transform.position;
    }

    void Update()
    {
        //If hasStarted evaluates to true, lock ball to paddle and launch the ball.
        if (!hasStarted) 
        {
            LockBallToPaddle();
            LaunchBallOnLeftMouseClick();
        }
    }

    //Method has been created to refactorize code in Update().
    private void LockBallToPaddle() 
    {
        //Get the current x and y positions of the paddle.
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);

        //Set the position of the ball to be equal to the distance and position of the paddle.
        transform.position = paddleToBallDistance + paddlePosition;
    }

    private void LaunchBallOnLeftMouseClick() 
    {
        //0 represents left mouse click
        if (Input.GetMouseButtonDown(0)) 
        {
            //Indicate that the ball has started moving.
            hasStarted = true;

            /* Access the ball's Rigidbody2D physics component
             * and give it a velocity to give it a force upwards. */
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPosition, yPosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /* Whenever the ball collides with an object, 
         * check whether or not the paddle has left the paddle
         * and started moving. If yes, retrieve the audio source 
         * component from the Ball game object and play the audio clip. */
        if (hasStarted)
        {
            //Select a random sound effect from the list of available SFX.
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];

            /* PlayOneShot can play multiple sounds without cutting each other off.
             * However, this means that the audio clip cannot be stopped and it will 
             * just play all the way through with no way to stop it manually/early. */
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
