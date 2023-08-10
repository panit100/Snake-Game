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
        if(GameManager.Instance.currentStage == GameStage.START)
        {
            StartCoroutine(Move());
            GameManager.Instance.OnChangeStage(GameStage.PLAYING);
        }
    }

    void GetDirection()
    {
        Vector2 tempDirection;

        if(Input.GetKeyDown(KeyCode.A))
        {
            tempDirection = Vector2.left;
            if(UpdateDirection(tempDirection))
                transform.rotation = Quaternion.Euler(new Vector3(0,0,180));
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            tempDirection = Vector2.right;
            if(UpdateDirection(tempDirection))
                transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            tempDirection = Vector2.up;
            if(UpdateDirection(tempDirection))
                transform.rotation = Quaternion.Euler(new Vector3(0,0,90));
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            tempDirection = Vector2.down;
            if(UpdateDirection(tempDirection))
                transform.rotation = Quaternion.Euler(new Vector3(0,0,270));
        }
    }

    bool UpdateDirection(Vector2 tempDirection)
    {
        if(tempDirection != direction * -1)
        {
            direction = tempDirection;
            StartMove();
            return true;
        }

        return false;   
    }

    IEnumerator Move()
    {
        snakeBody.UpdateNextPosition(transform.position);

        transform.position += (Vector3)direction;
        BoardManager.Instance.AddEmptyGrid((int)transform.position.x,(int)transform.position.y);

        snakeBody.UpdatePosition();
        yield return new WaitForSeconds(.5f);
        move = StartCoroutine(Move());
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Boarder") || other.CompareTag("SnakeBody"))
        {
            StopCoroutine(move);    
            GameManager.Instance.OnChangeStage(GameStage.END);
        }
    }

    public void AddBody()
    {
        SnakeBody tempSnakeBody = snakeBody;

        while(tempSnakeBody.nextNode != null)
        {
            tempSnakeBody = tempSnakeBody.nextNode;
        }

        var newSnakeBody = Instantiate(snakeBodyPrefab,tempSnakeBody.transform.position,Quaternion.identity);

        tempSnakeBody.nextNode = newSnakeBody;
    }   
}