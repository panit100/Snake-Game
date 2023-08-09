using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public static AppleSpawner Instance { get; private set;}

    public AppleScript apple;

    private void Awake() 
    {
        Instance = this;
    }

    Vector2 GetRandomPositionOnGrid()
    {
        Vector2 randomPosition = new Vector2(Random.Range(0,BoardManager.Instance.width), Random.Range(0,BoardManager.Instance.height));
        return randomPosition;
    }

    public void SpawnAppleOnGrid()
    {
        Instantiate(apple,GetRandomPositionOnGrid(),Quaternion.identity);
    }
}
