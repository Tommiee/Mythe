using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField]
    private int rows, colums = 0;

    private Tile[,] gridArray;

    private float gridSizeX;
    private float cubeSizeX;

    private float gridSizeZ;
    private float cubeSizeZ;

    private int[] inventoryPosX;
    private int[] inventoryPosZ;

    void Start()
    {
        gridArray = new Tile[rows, colums];

        inventoryPosX = new int[] { 1, 2, 3, 9, 10, 11, 12};
        inventoryPosZ = new int[] { 1, 7 };

        gridSizeX = GetComponent<Renderer>().bounds.size.x;
        cubeSizeX = gridSizeX / rows;

        gridSizeZ = GetComponent<Renderer>().bounds.size.z;
        cubeSizeZ = gridSizeZ / colums;

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
        int posX = inventoryPosX[Random.Range(0, inventoryPosX.Length)];
        int posY = inventoryPosZ[Random.Range(0, inventoryPosZ.Length)];
//        while(gridArray[posX, posY].full)
//        {
//            posX = inventoryPos[Random.Range(0, inventoryPos.Length)];
//            posY = inventoryPos[Random.Range(0, inventoryPos.Length)];
//        }
//        gridArray[posX, posY].full = true;
        return new Vector3(gridArray[posX, posY].x, gridArray[posX, posY].y, gridArray[posX, posY].z);
    }

    public Vector3 GetPosCraft()
    {
        int posX = Random.Range(5, 9);
        int posY = Random.Range(2, 6);

//        while (gridArray[posX, posY].full)
//        {
//            posX = Random.Range(5, 7);
//            posY = Random.Range(5, 7);
//        }
//        gridArray[posX, posY].full = true;
        return new Vector3(gridArray[posX, posY].x, gridArray[posX, posY].y, gridArray[posX, posY].z);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < rows; x++)
        {
            for (float z = 0; z < colums; z++)
            {
                float gridSizeX = GetComponent<Renderer>().bounds.size.x;
                float cubeSizeX = 1 * (gridSizeX / rows);

                float gridSizeZ = GetComponent<Renderer>().bounds.size.z;
                float cubeSizeZ = 1 * (gridSizeZ / colums);

                float positionX = transform.position.x + x * (gridSizeX / rows) - gridSizeX / 2 + cubeSizeX / 2;
                float positionY = transform.position.y;
                float positionZ = transform.position.z + z * (gridSizeZ / colums) - gridSizeZ / 2 + cubeSizeZ / 2;

                Gizmos.DrawWireCube(new Vector3(positionX, positionY, positionZ), new Vector3(cubeSizeX, 1, cubeSizeZ));
            }
        }
    }

}