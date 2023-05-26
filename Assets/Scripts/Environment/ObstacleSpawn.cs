using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField]
    private ObstacleMovement obstacle;

    private float timeToWait;
    private float range;

    [SerializeField]
    private DifficultyAdjustment[] difficultyAdjustment;

    private ScoreManager scoreManager;
    private int currentDifficulty = 0;
    private float currentObstacleSpeed;

    void Start()
    {
        StartCoroutine(Spawner());
        scoreManager = ScoreManager.Instance;
        currentObstacleSpeed = difficultyAdjustment[0].obstacleSpeed;
        timeToWait = difficultyAdjustment[0].timeToWait;
        range = difficultyAdjustment[0].range;
    }

    void Update()
    {
        if (currentDifficulty + 1 < difficultyAdjustment.Length)
        {
            if (scoreManager.score >= difficultyAdjustment[currentDifficulty + 1].score)
            {
                currentDifficulty++;
                timeToWait = difficultyAdjustment[currentDifficulty].timeToWait;
                range = difficultyAdjustment[currentDifficulty].range;

            }
        }
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            var obj = Instantiate(obstacle, new Vector3(transform.position.x, Random.Range(-range + 0.09f, range + 0.09f), 0), transform.rotation);
            obj.movementSpeed = currentObstacleSpeed;

            yield return new WaitForSeconds(timeToWait);
        }
    }

    [System.Serializable]
    public struct DifficultyAdjustment
    {
        public int score;
        public float timeToWait;
        public float range;
        public float obstacleSpeed;
    }
}
