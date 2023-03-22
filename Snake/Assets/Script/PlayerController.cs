using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Malle.Util;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField]
    public Tilemap Map;
    [SerializeField]
    public TileBase[] Tiles;

    private Direction currentDir;
    private Direction lastDir;

    private Vector3Int currentPos = Vector3Int.left;

    private int currentX = DataManager.MaxGridX / 2;
    private int currentY = DataManager.MaxGridY / 2;
    private float visualHeadRot = 0f;

    private float tickAmount;
    private float tickMax;
    private float tickCurrent;

    private void Awake()
    {
        Instance = this;

        Init();
    }

    public void Init()
    {
        DataManager.SnakePosList.Clear();
        DataManager.Score = 0;
        DataManager.IsPlayerDead = false;

        currentDir = Direction.up;
        tickAmount = 0;
        tickMax = 256;
        tickCurrent = 0;

        currentX = DataManager.MaxGridX / 2;
        currentY = DataManager.MaxGridY / 2;
        visualHeadRot = 0f;

        currentPos = DataManager.Offset + new Vector3Int(currentX, currentY, 0);

        Map.SetTile(currentPos, Tiles[0]);
        DataManager.SnakePosList.Add(currentPos);

        for (int i = 0; i < 2; i++)
        {
            int tempY = currentPos.y - i - 1;

            Vector3Int finalPos = new Vector3Int(currentPos.x, tempY, 0);
            Map.SetTile(finalPos, Tiles[1]);

            DataManager.SnakePosList.Add(finalPos);
        }
    }

    void Update()
    {
        InputHandler();

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

            currentPos = DataManager.Offset;
            currentPos.x += currentX;
            currentPos.y += currentY;

            foreach (var item in DataManager.PelletPosList)
            {
                if (currentPos == item)
                {
                    DataManager.SnakePosList.Add(DataManager.SnakePosList[DataManager.SnakePosList.Count - 1]);
                    DataManager.PelletPosList.Remove(item);
                    DataManager.Score++;
                    break;
                }
            }

            //save down snake body pos
            List<Vector3Int> tempSnakeList = new List<Vector3Int>();
            for (int i = DataManager.SnakePosList.Count-2; i > -1; i--)
                tempSnakeList.Add(DataManager.SnakePosList[i]);
            tempSnakeList.Add(currentPos);
            tempSnakeList.Reverse();

            DataManager.SnakePosList = tempSnakeList;

            DataManager.IsPlayerDead = DeadCheck();

            lastDir = currentDir;

            //visual
            DrawBoard.Draw(Map, Tiles, World.Instance.Tiles);
        }
        else
        {
            tickCurrent += tickAmount;
        }

        SpeedCalc();
    }

    private void SpeedCalc()
    {
        if (DataManager.IsPlayerDead)
            tickAmount = 0;
        else if (DataManager.IsStarted)
            tickAmount = 0.75f + (DataManager.Score * 0.05f);
    }

    public bool DeadCheck()
    {
        bool borderCheck = currentX >= DataManager.MaxGridX || currentX < 0 || currentY >= DataManager.MaxGridY || currentY < 0;
        bool onBody = false;

        for (int i = 1; i < DataManager.SnakePosList.Count; i++)
        {
            if (currentPos == DataManager.SnakePosList[i])
            {
                onBody = true;
                break;
            }
        }

        return borderCheck || onBody;
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
        
        Map.SetTransformMatrix(currentPos, Matrix4x4.Rotate(Quaternion.Euler(0f, 0f, visualHeadRot)));
    }
}

public enum Direction
{
    up,
    right,
    down,
    left,
}
