using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridPosition
{
    int x, y;

   public GridPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }



    public override string ToString()
    {
        return $"x: {x} ; y: {y}";
    }
}