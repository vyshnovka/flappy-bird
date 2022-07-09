using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;

    [SerializeField]
    private float timeToWait;
    [SerializeField]
    private float range;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            Instantiate(obstacle, new Vector3(transform.position.x, Random.Range(-range + 0.09f, range + 0.09f), 0), transform.rotation);

            yield return new WaitForSeconds(timeToWait);
        }
    }
}
