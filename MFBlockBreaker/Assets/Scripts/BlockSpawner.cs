using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    //As we will be dealing with multiple blocks.
    GameObject[] blocks;
    GameObject randomBlock;
    //Two Vector2 variables for the blocks' destination and starting position.
    Vector2 blockPosition, startingBlockPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingBlockPosition = transform.position;
        LoadBlocksFromResources();
        PrintBlocksOnXAndY();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* Load all files in Resources/Blocks in the array blocks, 
     * set the position of the blockPosition to the position of the 1st block (top left). */
    private void LoadBlocksFromResources() 
    {
        //Load all files in Resources/Blocks inside the array.
        blocks = Resources.LoadAll<GameObject>("Blocks");
        //Set the block's position to the position of the first block.
        blockPosition = transform.position;
    }

    private void GetRandomBlock() 
    {
        int randomNumber = Random.Range(0, blocks.Length);
        //Select random block from the array.
        randomBlock = blocks[randomNumber];
    }

    private void SpawnBlocks() 
    {
        //Clone original object - create an object.
        Instantiate(randomBlock, blockPosition, transform.rotation);
    }

    /* Spawn blocks and update the position after each block 
     * so that we end up with a list of blocks. */
    private void PrintBlocksOnXAndY() 
    {
        for (int y = 5; y > 1; y--) 
        {
            //Print block from left to right.
            for (int x = 1; x < 15; x += 2) 
            {
                GetRandomBlock();
                SpawnBlocks();
                blockPosition.x += 2;
            }

            //Set x position to starting position.
            blockPosition.x = startingBlockPosition.x;
            //Set y position to below the previous position.
            blockPosition.y -= 2;
        }
    }
}
