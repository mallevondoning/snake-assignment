using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Malle.Util
{
    public static class DrawBoard
    {
        public static void Draw(Tilemap map, TileBase[] snakes, TileBase[] pellets)
        {
            map.ClearAllTiles();
            for (int i = 0; i < DataManager.SnakePosList.Count; i++)
            {
                if (i == 0)
                    map.SetTile(DataManager.SnakePosList[i], snakes[0]);
                else
                    map.SetTile(DataManager.SnakePosList[i], snakes[1]);
            }

            for (int i = 0; i < DataManager.PelletPosList.Count; i++)
            {
                map.SetTile(DataManager.PelletPosList[i], pellets[0]);
            }
        }
    }
}
