using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public Transform lastPlatform;
    Vector3 lasPos;
    Vector3 newPos;

    public bool stop;

    void Start()
    {
        lasPos = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());
        
    }
    void GeneratePos()
    {
        newPos = lasPos;
        int rand = Random.Range(0, 2); // 0 1 2
        if (rand >0)
        {
            newPos.x += 2f;
        }
        else
        {
            newPos.z += 2f;
        }
    }
    IEnumerator SpawnPlatforms()
    {
        while (!stop)
        {
            GeneratePos();
            Instantiate(platform, newPos, Quaternion.identity);
            lasPos = newPos;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
