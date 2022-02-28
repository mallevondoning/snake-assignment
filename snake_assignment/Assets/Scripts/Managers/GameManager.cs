using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<GameObject> snakeBodyPartList = new List<GameObject>();

    public static int gridMaxX { get; set; }
    public static int gridMaxY { get; set; }
    public static int snakeLength { get; set; }
}
