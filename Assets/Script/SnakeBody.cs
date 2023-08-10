using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeBody : MonoBehaviour
{
    public SnakeBody nextNode;

    Vector3 nextPosition;

    Vector2 tempPosition;

    public void UpdatePosition()
    {
        tempPosition = transform.position;

        transform.position = nextPosition;
        
        if(nextNode != null)
            nextNode.UpdatePosition();
        else
        {
            BoardManager.Instance.RemoveEmptyGrid((int)tempPosition.x,(int)tempPosition.y);
        }
    }

    public void UpdateNextPosition(Vector3 _nextPosition)
    {
        nextPosition = _nextPosition;

        if(nextNode != null)
            nextNode.UpdateNextPosition(transform.position);
    }
}
