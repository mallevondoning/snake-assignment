using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UIButton : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;
    [SerializeField]
    private TileBase[] tiles;

    public void ClearBoard() {
        map.ClearAllTiles();
    }

    public void PaintTest()
    {
        map.SetTile(new Vector3Int(-1, 0, 0), null);
    }
}
