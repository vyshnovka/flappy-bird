using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }
}
