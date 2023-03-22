using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class World : MonoBehaviour
{
    public static World Instance { get; set; }

    [SerializeField]
    public Tilemap Map;
    [SerializeField]
    public TileBase[] Tiles;

    private Vector3Int lastPos;
    private bool onSnake;

    private void Awake()
    {
        Instance = this;

        Init();
    }

    private void Update()
    {
        if (DataManager.PelletPosList.Count <= 0)
        {
            SpawnPellet();
        }
    }

    public void Init()
    {
        DataManager.PelletPosList.Clear();

        SpawnPellet();
        Map.SetTile(DataManager.PelletPosList[0], Tiles[0]);
    }

    public void SpawnPellet()
    {
        Vector3Int finalPos;

        int loop = 0;
        do
        {
            finalPos = GetRandomPos();
            loop++;

            onSnake = false;
            foreach (var item in DataManager.SnakePosList)
            {
                if (finalPos == item)
                {
                    onSnake = true;
                    loop = 0;
                    break;
                }
            }

            if (loop >= 100)
            {
                Debug.Log("got stuck");
                break;
            }
        } while (finalPos == lastPos || onSnake);

        Map.SetTile(finalPos, Tiles[0]);

        DataManager.PelletPosList.Add(finalPos);

        lastPos = finalPos;
    }

    public Vector3Int GetRandomPos()
    {
        int rngX = Random.Range(0, DataManager.MaxGridX - 1);
        int rngY = Random.Range(0, DataManager.MaxGridY - 1);

        return DataManager.Offset + new Vector3Int(rngX, rngY, 0);
    }
}
