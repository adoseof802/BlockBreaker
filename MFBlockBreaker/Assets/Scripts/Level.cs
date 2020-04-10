using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //To keep track of the amount of blocks.
    [SerializeField] int breakableBlock;

    //Link SceneLoader to Levels.
    SceneLoader sceneLoader;

    public void CountBreakableBlocks() 
    {
        //For each block found, increment breakableBlock by 1.
        breakableBlock++;
    }

    public void BlockDestroyCount() 
    {
        //If a block is destroyed, decrement breakableBlock by 1.
        breakableBlock--;

        //Go to the next Level if there are no more blocks to destroy.
        if (breakableBlock <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
