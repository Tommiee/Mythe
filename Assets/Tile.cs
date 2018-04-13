using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    public Tile(float xCord,float yCord, float zCord)
    {
        x = xCord;
        y = yCord;
        z = zCord;
    }

    public float x;
    public float y;
    public float z;

    public bool full;
}
