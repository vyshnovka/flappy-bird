using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueManager : MonoBehaviour
{
    public static MonologueManager instance;

    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject bubble;

    [SerializeField]
    private GameObject decisionButtons;

    [SerializeField]
    private GameObject blackBlock;

    void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        Time.timeScale = 1;
    }

    public void StartMonologue()
    {
        playButton.SetActive(false);
        AudioController.instance.PlayTap();

        StartCoroutine(Utility.TimedEvent(() =>
        {
            bubble.SetActive(true);
        }, 2f));
    }

    public void ShowDecisionBlock()
    {
        bubble.SetActive(!bubble.activeSelf);

        decisionButtons.SetActive(!decisionButtons.activeSelf);
    }

    public void EndingAnimation()
    {
        blackBlock.SetActive(true);

        StartCoroutine(Utility.TimedEvent(() =>
        {
            SceneLoader.Load(0);
        }, 3f));
    }
}
