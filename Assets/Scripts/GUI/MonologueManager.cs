using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playButton;

    [SerializeField]
    private GameObject bubble;

    public void StartMonologue()
    {
        playButton.SetActive(false);

        StartCoroutine(Utility.TimedEvent(() =>
        {
            bubble.SetActive(true);
        }, 2f));
    }
}
