using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    private float timer;
    public float deltaTime;
   
    public GameObject obstacle;
    public float range;

    void Update()
    {
        if (timer > deltaTime)
        {
            GameObject obstacleClone = Instantiate(obstacle);
            obstacleClone.transform.position = transform.position + new Vector3(0, Random.Range(-range, range + 0.6f), 0);

            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
