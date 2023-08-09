using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeBody : MonoBehaviour
{
    public SnakeBody nextNode;

    Vector3 nextPosition;

    public void UpdatePosition()
    {
        transform.position = nextPosition;
        if(nextNode != null)
            nextNode.UpdatePosition();
    }

    public void UpdateNextPosition(Vector3 _nextPosition)
    {
        nextPosition = _nextPosition;

        if(nextNode != null)
            nextNode.UpdateNextPosition(transform.position);
    }
}
