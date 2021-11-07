using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagement : MonoBehaviour
{
    public enum States
    {
        Start, Play, Restart
    }
    public static States state;

    public GameObject StartUI;
    public GameObject RestartUI;
    public GameObject Score;

    public GameObject Text;

    public float moveScoreY = 0f;

    void Start()
    {
        RestartUI.SetActive(false);
        Score.SetActive(false);

        Time.timeScale = 0;
    }

    public void Awake()
    {
        state = States.Start;
    }

    void Update()
    {
        switch (state)
        {
            case States.Start:
                StartUI.SetActive(true);

                if (Input.GetMouseButtonUp(0))
                {
                    Time.timeScale = 1;
                    UIManagement.state = UIManagement.States.Play;
                    StartUI.SetActive(false);
                } 

                break;
            case States.Play:
                Score.SetActive(true);

                break;
            case States.Restart:
                RestartUI.SetActive(true);
                Text.transform.position = new Vector3(0f, moveScoreY, 0f); ;
                
                Time.timeScale = 0;

                if (Input.GetMouseButtonUp(0))
                {
                    UIManagement.state = UIManagement.States.Play;
                    RestartUI.SetActive(false);
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
                }

                break;
        }
    }
}
