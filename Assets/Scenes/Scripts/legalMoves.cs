using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legalMoves : MonoBehaviour
{
    public static ArrayList compute(ArrayList currentTiles, int sumDices, int sumSelectedTiles)
    {
        var tmp = currentTiles;
        var array = new ArrayList();

        if (tmp.Contains(sumDices - sumSelectedTiles)) array.Add(sumDices - sumSelectedTiles);
        for (int i = 1; i <= (sumDices - i); i++)
        {
            if (!tmp.Contains(i)) continue;
            if (i + sumSelectedTiles == sumDices)
                if (!array.Contains(i))
                    array.Add(i);
            for (var x = i + 1; x <= (sumDices - i); x++)
            {
                if (!tmp.Contains(x)) continue;
                if (i + x + sumSelectedTiles == sumDices)
                {
                    if (!array.Contains(x)) array.Add(x);
                    if (!array.Contains(i)) array.Add(i);
                }
                else
                {
                    for (var y = x + 1; y <= (sumDices - y); y++)
                    {
                        if (!tmp.Contains(y)) continue;
                        if (i + x + y + sumSelectedTiles != sumDices) continue;
                        if (!array.Contains(x)) array.Add(x);
                        if (!array.Contains(i)) array.Add(i);
                        if (!array.Contains(y)) array.Add(y);
                    }
                }
            }
        }
        return array;
    }
}
