using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField]
    private float rows, colums;
    private float gridSize = 10;

    public Tile[,] gridArray;

    float gridSizeX;
    float cubeSizeX;

    float gridSizeZ;
    float cubeSizeZ;

    public GameObject cube;

    void Start()
    {
        CreateGrid();

        gridSizeX = 10 * transform.localScale.x;
        cubeSizeX = 1 * (gridSizeX / rows);

        gridSizeZ = 10 * transform.localScale.z;
        cubeSizeZ = 1 * (gridSizeZ / colums);
    }

    void CreateGrid()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int z = 0; z < colums; z++)
            {
                float positionX = transform.position.x + x * (gridSizeX / rows) - gridSizeX / 2 + cubeSizeX / 2;
                float positionY = transform.position.y;
                float positionZ = transform.position.z + z * (gridSizeZ / colums) - gridSizeZ / 2 + cubeSizeZ / 2;

                gridArray[x, z] = new Tile(positionX, positionY, positionZ);
                Instantiate(cube, new Vector3(gridArray[0, 0].x, gridArray[0, 0].y, gridArray[0, 0].z), Quaternion.identity);
            }
        }
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