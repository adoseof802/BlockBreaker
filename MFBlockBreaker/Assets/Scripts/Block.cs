using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //The collision would the ball.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Get the name of the gameObject which collided with the block.
        print(collision.gameObject.name);
        //Destroy the game object to which the script is attached. (in this case, the block)
        Destroy(this.gameObject);
    }
}
