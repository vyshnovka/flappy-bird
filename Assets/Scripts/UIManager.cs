using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private GameObject startUI;
    [SerializeField]
    private GameObject restartUI;
    [SerializeField]
    private Text scoreText;

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
        Time.timeScale = 0;
    }

    public void ShowRestartUI()
    {
        Time.timeScale = 0;
        scoreText.gameObject.SetActive(false);
        restartUI.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startUI.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        restartUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
