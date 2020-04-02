using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn : MonoBehaviour
{
    public GameObject tile;
    public Vector3 spawnPlace;
    public int wideLength;
    public int heightLength;

    void Start()
    {
        spawnPlace.x = 6;
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        spawnPlace.y += -1;
        spawnPlace.x = 6;
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        spawnPlace.y += -1;
        spawnPlace.x = 6;
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        spawnPlace.y += -1;
        spawnPlace.x = 6;
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        spawnPlace.y += -1;
        spawnPlace.x = 6;
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        spawnPlace.y += -1;
        spawnPlace.x = 6;
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        Tile();
        spawnPlace.y += -1;
        spawnPlace.x = 6;
    }

   
    
    public void Tile()
    {
        
        transform.position = spawnPlace;
        Instantiate(tile, transform.position, Quaternion.identity);
        spawnPlace.x += -1;
    }
}
