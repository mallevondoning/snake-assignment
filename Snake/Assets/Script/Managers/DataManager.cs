using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static List<Vector3Int> PelletPosList = new List<Vector3Int>();
    public static List<Vector3Int> SnakePosList = new List<Vector3Int>();

    public static int MaxGridX = 10;
    public static int MaxGridY = 10;
    public static Vector3Int Offset = new Vector3Int(-MaxGridX / 2, -MaxGridY / 2, 0);

    public static int Score = 0;
}
