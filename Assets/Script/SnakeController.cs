using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public SnakeBody snakeBody;
    public SnakeBody snakeBodyPrefab;

    Vector2 direction;

    Coroutine move;
    
    void Update()
    {
        GetDirection();
    }

    void StartMove()
    {
        if(move == null)
        {
            StartCoroutine(Move());
        }
    }

    void GetDirection()
    {
        Vector2 tempDirection;

        if(Input.GetKeyDown(KeyCode.A))
        {
            tempDirection = Vector2.left;
            UpdateDirection(tempDirection);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            tempDirection = Vector2.right;
            UpdateDirection(tempDirection);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            tempDirection = Vector2.up;
            UpdateDirection(tempDirection);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            tempDirection = Vector2.down;
            UpdateDirection(tempDirection);
        }
    }

    void UpdateDirection(Vector2 tempDirection)
    {
        if(tempDirection != direction * -1)
            direction = tempDirection;

        StartMove();
    }

    IEnumerator Move()
    {
        snakeBody.UpdateNextPosition(transform.position);

        transform.position += (Vector3)direction;

        snakeBody.UpdatePosition();
        yield return new WaitForSeconds(.5f);
        move = StartCoroutine(Move());
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Boarder") || other.CompareTag("SnakeBody"))
            StopCoroutine(move);    
    }

    public void AddBody()
    {
        SnakeBody tempSnakeBody = snakeBody;

        while(tempSnakeBody.nextNode != null)
        {
            tempSnakeBody = tempSnakeBody.nextNode;
        }

        var newSnakeBody = Instantiate(snakeBodyPrefab,tempSnakeBody.transform);

        tempSnakeBody.nextNode = newSnakeBody;
    }   
}
