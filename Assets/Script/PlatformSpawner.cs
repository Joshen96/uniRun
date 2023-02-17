using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformprefab;

    public int count = 3;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;

    float timeBetSpawn;

    public float yMin = -3.5f;
    public float ymax = 1.5f;

    float xPos = 20f;

    GameObject[] platforms;

    int currentIndex = 0;

    Vector2 poolPosition = new Vector2(0, -25);
    float lastSpawnTime;
    void Start()
    {
        platforms = new GameObject[count];
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
