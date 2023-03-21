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
    private Direction lastDir;

    private Vector3Int currentPos = Vector3Int.left;

    private Vector3Int offset;
    private int currentX = 5;
    private int currentY = 5;
    private float visualHeadRot = 0f;
    private float visualTailRot = 0f;

    private int gridXMax = 10;
    private int gridYMax = 10;

    private int length = 3;

    private float tickAmount;
    private float tickMax;
    private float tickCurrent;

    private void Awake()
    {
        currentDir = Direction.up;
        tickAmount = 1;
        tickMax = 256;

        offset = new Vector3Int(-currentX, -currentY, 0);
        currentPos = offset + new Vector3Int(currentX, currentY, 0);

        map.SetTile(currentPos, tiles[0]);
    }

    void Update()
    {
        InputHandler();

        if (currentX >= gridXMax) { }
        if (currentX < 0) { }
        if (currentY >= gridYMax) { }
        if (currentY < 0) { }

        if (tickCurrent >= tickMax)
        {
            tickCurrent = 0;
            
            switch (currentDir)
            {
                case Direction.up:
                    currentY += 1;
                    visualHeadRot = 0f;
                    break;
                case Direction.right:
                    currentX += 1;
                    visualHeadRot = 270f;
                    break;
                case Direction.down:
                    currentY -= 1;
                    visualHeadRot = 180f;
                    break;
                case Direction.left:
                    currentX -= 1;
                    visualHeadRot = 90f;
                    break;
            }


            currentPos = offset;
            currentPos.x += currentX;
            currentPos.y += currentY;

            map.ClearAllTiles();
            map.SetTile(currentPos, tiles[0]);

            lastDir = currentDir;
        }
        else
        {
            tickCurrent += tickAmount;
        }
    }

    
    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.W) && lastDir != Direction.down)
            currentDir = Direction.up;
        if (Input.GetKeyDown(KeyCode.S) && lastDir != Direction.up)
            currentDir = Direction.down;
        if (Input.GetKeyDown(KeyCode.D) && lastDir != Direction.left)
            currentDir = Direction.right;
        if (Input.GetKeyDown(KeyCode.A) && lastDir != Direction.right)
            currentDir = Direction.left;
        
        map.SetTransformMatrix(currentPos, Matrix4x4.Rotate(Quaternion.Euler(0f, 0f, visualHeadRot)));
    }
}

public enum Direction
{
    up,
    right,
    down,
    left,
}
