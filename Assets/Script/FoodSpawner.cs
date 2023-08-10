using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public static FoodSpawner Instance { get; private set;}

    [SerializeField] FoodScript food;

    private void Awake() 
    {
        Instance = this;
    }

    Vector2 GetRandomPositionOnGrid()
    {
        var width = Random.Range(0,BoardManager.Instance.width);
        var height = Random.Range(0,BoardManager.Instance.height);

        while(BoardManager.Instance.notEmptyGridList.Find(n => n == BoardManager.Instance.grids[width,height]))
        {
            width = Random.Range(0,BoardManager.Instance.width);
            height = Random.Range(0,BoardManager.Instance.height);
        }

        Vector2 randomPosition = new Vector2(width, height);

        return randomPosition;
    }

    public void SpawnAppleOnGrid()
    {
        Instantiate(food,GetRandomPositionOnGrid(),Quaternion.identity);
    }
}
