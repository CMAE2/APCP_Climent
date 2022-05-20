using System.Collections;
using System.Collections.Generic;
using UnityEngine;







public static class Noise
{
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHight, float scale, int octaves, float Persistance, float lacunarity)
    {
        float[,] noiseMap = new float[mapWidth, mapHight];
        if (scale <= 0) 
        {
            scale = 0.0001f;
        }
        float maxNoiseHight = float.MinValue;
        float minNoiseHight = float.MaxValue;

        for (int y = 0; y < mapHight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float amplitude = 1;
                float Frequency = 1;
                float noiseHight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = x / scale * Frequency;
                    float sampleY = y / scale * Frequency;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHight += perlinValue * amplitude;

                    amplitude *= Persistance;
                    Frequency *= lacunarity;
                    

                }
                if(noiseHight > maxNoiseHight)
                {
                    maxNoiseHight = noiseHight;
                }
                else if(noiseHight < minNoiseHight)
                {
                    minNoiseHight = noiseHight;
                }
                noiseMap[x, y] = noiseHight;
                        
            }
        }
        for (int y = 0; y < mapHight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHight, maxNoiseHight, noiseMap[x, y]);
            }
        }
        return noiseMap;
    }
    





}
