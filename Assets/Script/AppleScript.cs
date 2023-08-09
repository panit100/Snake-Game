using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Snake")
        {
            other.GetComponent<SnakeController>().AddBody();
            AppleSpawner.Instance.SpawnAppleOnGrid();
            ScoreManager.Instance.IncreaseScore();

            Destroy(this.gameObject);
        }

    }
}
