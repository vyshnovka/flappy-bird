using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playButton;

    public void StartMonologue()
    {
        playButton.SetActive(false);
    }
}
