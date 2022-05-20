using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    
    public int mapWidth;
    public int mapHight;
    public float noiseScale;

    public int octaves;
    public float Persistance;
    public float lacunarity;

    public bool autoUpdate;


    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapWidth, mapHight, noiseScale, octaves, Persistance, lacunarity);


        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }
}
