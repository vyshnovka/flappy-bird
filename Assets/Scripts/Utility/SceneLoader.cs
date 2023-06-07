using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void Load(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
