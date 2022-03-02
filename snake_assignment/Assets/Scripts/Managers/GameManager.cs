using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<GameObject> snakeBodyPartList = new List<GameObject>();

    public static int gridMaxX { get; set; } = 10;
    public static int gridMaxY { get; set; } = 10;
    public static int snakeLength { get; set; } = 3;

    private void Awake()
    {
    }
}
