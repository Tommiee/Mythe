using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField]
    private float rows, colums;
    private float gridSize = 10;

    [SerializeField]
    private float cubeSize = 1;

    void Start()
    {
        print(GetNearestPointOnGrid(new Vector3()));
    }
     
    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x);
        int yCount = Mathf.RoundToInt(position.y);
        int zCount = Mathf.RoundToInt(position.z);

        Vector3 result = new Vector3(
            (float)xCount,
            (float)yCount,
            (float)zCount);

        result += transform.position;

        return result;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < rows; x++)
        {
            for (float z = 0; z < colums; z++)
            {
                Gizmos.DrawWireCube((new Vector3(transform.position.x - gridSize / 2 + cubeSize/2 + x, transform.position.y, transform.position.z - gridSize / 2 + cubeSize/2 + z)), new Vector3(cubeSize, cubeSize, cubeSize));
            }
        }
    }
}
