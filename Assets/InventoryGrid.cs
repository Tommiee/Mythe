using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField]
    private int rows, colums;
    private float gridSize = 10;

    public Tile[,] gridArray;

    float gridSizeX;
    float cubeSizeX;

    float gridSizeZ;
    float cubeSizeZ;

    private int[] inventoryPos;
    private int[] craftPos;

    public GameObject cube;

    void Start()
    {
        gridArray = new Tile[rows, colums];

        inventoryPos = new int[] { 1, 2, 3, 4, 8, 9, 10, 11 };

        gridSizeX = 10 * transform.localScale.x;
        cubeSizeX = 1 * (gridSizeX / rows);

        gridSizeZ = 10 * transform.localScale.z;
        cubeSizeZ = 1 * (gridSizeZ / colums);

        CreateGrid();
    }

    private void CreateGrid()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int z = 0; z < colums; z++)
            {
                float positionX = transform.position.x + x * (gridSizeX / rows) - gridSizeX / 2 + cubeSizeX / 2;
                float positionY = transform.position.y;
                float positionZ = transform.position.z + z * (gridSizeZ / colums) - gridSizeZ / 2 + cubeSizeZ / 2;

                gridArray[x, z] = new Tile(positionX, positionY, positionZ);
            }
        }
    }

    public Vector3 GetPosInv()
    {
        int posX = inventoryPos[Random.Range(0, inventoryPos.Length)];
        int posY = inventoryPos[Random.Range(0, inventoryPos.Length)];

        while(gridArray[posX, posY].full)
        {
            posX = inventoryPos[Random.Range(0, inventoryPos.Length)];
            posY = inventoryPos[Random.Range(0, inventoryPos.Length)];
        }
//        gridArray[posX, posY].full = true;
        return new Vector3(gridArray[posX, posY].x, gridArray[posX, posY].y, gridArray[posX, posY].z);
    }

    public Vector3 GetPosCraft()
    {
        int posX = Random.Range(5, 7);
        int posY = Random.Range(5, 7);

        while (gridArray[posX, posY].full)
        {
            posX = Random.Range(5, 7);
            posY = Random.Range(5, 7);
        }
//        gridArray[posX, posY].full = true;
        return new Vector3(gridArray[posX, posY].x, gridArray[posX, posY].y, gridArray[posX, posY].z);
    }

    //temp
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < rows; x++)
        {
            for (float z = 0; z < colums; z++)
            {
                float gridSizeX = 10 * transform.localScale.x;
                float cubeSizeX = 1 * (gridSizeX / rows);

                float gridSizeZ = 10 * transform.localScale.z;
                float cubeSizeZ = 1 * (gridSizeZ / colums);

                float positionX = transform.position.x + x * (gridSizeX / rows) - gridSizeX / 2 + cubeSizeX / 2;
                float positionY = transform.position.y;
                float positionZ = transform.position.z + z * (gridSizeZ / colums) - gridSizeZ / 2 + cubeSizeZ / 2;
                
                Gizmos.DrawWireCube(new Vector3(positionX, positionY, positionZ), new Vector3(cubeSizeX, 1, cubeSizeZ));
            }
        }
    }
    
}