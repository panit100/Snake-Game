using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Snake")
        {
            other.GetComponent<SnakeController>().AddBody();
            FoodSpawner.Instance.SpawnAppleOnGrid();
            ScoreManager.Instance.IncreaseScore();

            Destroy(this.gameObject);
        }

    }
}
