using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBoard : MonoBehaviour
{
    private int row = 8;
    private int column = 8;

    private float tileSize = 1.0f;

    public Tile[] tile;
    Dictionary<Vector2Int, Tile> tileDict = new Dictionary<Vector2Int, Tile>();

    public CharacterControl characterControlPrefab;

    void Start()
    {
        BoardGenerate();
    }

    void Update()
    {
        
    }

    private void BoardGenerate()
    {
        Tile whiteTile = tile[0];
        Tile blackTile = tile[1];

        for(int i = 0; i < row; i++)
        {
            for(int j = 0; j < column; j++)
            {
                Tile tilePrefeb = null;

                if(i % 2 == 0 && j % 2 == 0)
                {
                    tilePrefeb = whiteTile;
                }

                else if(i % 2 == 0 && j % 2 != 0)
                {
                    tilePrefeb = blackTile;
                }

                else if(i % 2 != 0 && j % 2 == 0)
                {
                    tilePrefeb = blackTile;
                }

                else if (i % 2 != 0 && j % 2 != 0)
                {
                    tilePrefeb = whiteTile;
                }

                Tile t = Instantiate(tilePrefeb, transform);
                float PosX = j * tileSize;
                float PosY = i * -tileSize;
                t.transform.position = new Vector2(PosX, PosY);
                t.Index = new Vector2Int(j, i);
                tileDict[t.Index] = t;
            }
        }

        float tileW = column * tileSize;
        float tileH = row * tileSize;

        transform.position = new Vector2(-tileW / 2 + tileSize / 2, tileH / 2 - tileSize / 2);

        Vector2Int spawnPos = new Vector2Int(Random.Range(0, 8), row -1);
        Instantiate(characterControlPrefab, GetTileAtIndex(spawnPos).transform.position, Quaternion.identity).Index = spawnPos;
    }

    public Tile GetTileAtWorldPosition(Vector3 pos)
    {
        float shortest = float.MaxValue;
        Tile closestTile = null;

        foreach (Tile t in tileDict.Values)
        {
            float distance = (t.transform.position - pos).sqrMagnitude;

            if (distance < shortest)
            {
                shortest = distance;
                closestTile = t;
            }
        }

        return closestTile;
    }

    public Tile GetTileAtIndex(Vector2Int index)
    {
        return tileDict[index];
    }
}
