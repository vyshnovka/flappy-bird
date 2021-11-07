using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public float floorSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector3.left * floorSpeed * Time.deltaTime);
    }
}
