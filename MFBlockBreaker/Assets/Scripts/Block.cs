using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Refers to the sound effect to be attached.
    [SerializeField] AudioClip breakSound;

    //Link Level class to this class.
    Level level;

    //Attach the sparkles effect.
    [SerializeField] GameObject blockSparklesVFX;

    void Start()
    {
        //Find object of type Level and save it to level object so we can access the method.
        level = FindObjectOfType<Level>();
        //Add 1 to the breakableBlocks variable.
        level.CountBreakableBlocks();

        /* Once the game is run and you check the SerializeBlock BreakableBlocks, 
         * you will see the total amount of blocks. */
    }

    //The collision would be the ball.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Get the name of the gameObject which collided with the block.
        print(collision.gameObject.name);

        //Access the GameStatus class to add points to the score.
        FindObjectOfType<GameStatus>().AddToScore();

        /* We will play a sound when the brick gets destroyed.
         * However we don't want the AudioSource attached to the game object 
         * to be destroyed as well. We will therefore play the sound even
         * when the GameObject is being destroyed by using PlayClipAtPoint().
         * The sound will play at the Camera's position. */
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

        //We will only destroy blocks with the Breakable tag.
        if (tag == "Breakable")
        {
            //Call the method for the effects.
            TriggerSparklesVFX();

            //Destroy the game object to which the script is attached. (in this case, the block)
            Destroy(this.gameObject);

            //Decrement breakableBlocks by 1 until there are no more blocks.
            level.BlockDestroyCount();
        }
    }

    private void TriggerSparklesVFX() 
    {
        //Create the particle effects at the block's current position and rotation.
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);

        /* Everytime a particle is created, it is cloned and left there 
         * so we will need to destroy it after some time. */

        //The second parameter is the amount of time to delay before destroying the object.
        Destroy(sparkles, 1f);
    }
}
