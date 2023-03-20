using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;
    [SerializeField]
    private TileBase[] tiles;

    private Direction currentDir;

    private float tickAmount;
    private float tickMax;
    private float tickCurrent;

    private void Awake()
    {
        currentDir = Direction.up;
        tickAmount = 1;
        tickMax = 256;

        map.SetTile(new Vector3Int(-1, 0, 0), tiles[0]);
        map.SetTile(new Vector3Int(-1, -1, 0), tiles[1]);
        map.SetTile(new Vector3Int(-1, -2, 0), tiles[2]);
    }

    void Update()
    {
        InputHandler();

        if (tickCurrent >= tickMax)
        {
            tickCurrent = 0;
            Debug.Log("moved");
        }
        else
        {
            tickCurrent += tickAmount;
        }
    }

    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentDir != Direction.down)
            currentDir = Direction.up;
        if (Input.GetKeyDown(KeyCode.S) && currentDir != Direction.up)
            currentDir = Direction.down;
        if (Input.GetKeyDown(KeyCode.D) && currentDir != Direction.left)
            currentDir = Direction.right;
        if (Input.GetKeyDown(KeyCode.A) && currentDir != Direction.right)
            currentDir = Direction.left;
    }
}


public enum Direction
{
    up,
    right,
    down,
    left,
}
