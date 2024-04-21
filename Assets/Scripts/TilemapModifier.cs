using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapModifier : MonoBehaviour
{
    public Tilemap dangerTilemap;
    public Tilemap safeTilemap;

    void Start()
    {
        RemoveDangerTiles();
    }

    void RemoveDangerTiles()
    {
        BoundsInt bounds = dangerTilemap.cellBounds;
        TileBase[] allTiles = dangerTilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase dangerTile = allTiles[x + y * bounds.size.x];
                if (dangerTile != null)
                {
                    Vector3Int localPlace = new Vector3Int(bounds.xMin + x, bounds.yMin + y, 0);
                    if (safeTilemap.HasTile(localPlace))
                    {
                        
                        dangerTilemap.SetTile(localPlace, null);
                    }
                }
            }
        }
    }
}