using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float movementSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }
}
