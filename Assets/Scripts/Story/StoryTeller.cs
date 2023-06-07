using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoryTeller : MonoBehaviour
{
    [SerializeField]
    private Plot plot;

    [SerializeField]
    private Text text;

    [SerializeField]
    [Range(0, 5)]
    private float timeToWait = 0.1f;

    private int lineIndex = 0;
    private string lineToDisplay = "";
    private string partToDisplay = "";

    private Coroutine coroutine;
    private bool isTyping = true;

    private bool hasDecided = false;

    void Start()
    {
        lineToDisplay = plot.lines[lineIndex];

        StartCoroutine(Utility.TimedEvent(() => {
            coroutine = StartCoroutine(TextWritter(lineToDisplay));
            isTyping = true;
        }, 0.2f));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                isTyping = false;
                StopCoroutine(coroutine);

                text.text = lineToDisplay;
            }
            else
            {
                if (lineIndex < plot.lines.Count - 1)
                {
                    lineIndex++;
                    lineToDisplay = plot.lines[lineIndex];

                    coroutine = StartCoroutine(TextWritter(lineToDisplay));
                }
                else
                {
                    if (!hasDecided)
                    {
                        MonologueManager.instance.ShowDecisionBlock();
                    }
                    else
                    {
                        MonologueManager.instance.EndingAnimation();
                    }
                }
            }
        }
    }

    private IEnumerator TextWritter(string line)
    {
        lineToDisplay = line;
        isTyping = true;

        for (int i = 0; i <= line.Length; i++)
        {
            partToDisplay = line.Substring(0, i);
            text.text = partToDisplay;

            yield return new WaitForSeconds(timeToWait);
        }

        isTyping = false;
        StopCoroutine(coroutine);
    }

    public void DeleteOption()
    {
        hasDecided = true;

        MonologueManager.instance.ShowDecisionBlock();
        coroutine = StartCoroutine(TextWritter("Thank you..."));

        PlayerPrefs.SetInt("Decision", 1);

        AudioController.instance.PlayTap();
    }

    public void LeaveOption()
    {
        hasDecided = true;

        MonologueManager.instance.ShowDecisionBlock();
        coroutine = StartCoroutine(TextWritter("It's your choice, I have no right to judge you."));

        PlayerPrefs.SetInt("Decision", 2);

        AudioController.instance.PlayTap();
    }
}
