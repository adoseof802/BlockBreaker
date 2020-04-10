using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Refers to the sound effect to be attached.
    [SerializeField] AudioClip breakSound;

    //The collision would be the ball.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Get the name of the gameObject which collided with the block.
        print(collision.gameObject.name);

        /* We will play a sound when the brick gets destroyed.
         * However we don't want the AudioSource attached to the game object 
         * to be destroyed as well. We will therefore play the sound even
         * when the GameObject is being destroyed by using PlayClipAtPoint().
         * The sound will play at the Camera's position. */
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        //Destroy the game object to which the script is attached. (in this case, the block)
        Destroy(this.gameObject);
    }
}
