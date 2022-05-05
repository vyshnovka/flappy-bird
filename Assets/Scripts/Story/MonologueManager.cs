using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueManager : MonoBehaviour
{
    [SerializeField]
    private PlotGenerator plot;

    [SerializeField]
    [Range(0, 5)]
    private float timeToWait = 0.1f;

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

    private IEnumerator StoryTeller()
    {
        yield return new WaitForSeconds(timeToWait);
    }
}
