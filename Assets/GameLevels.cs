using System;
using UnityEngine.SceneManagement;

public class GameLevels
{
    private readonly String[] levels = {
        "Title",
        "Rules",
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7"
    };

    public void Next()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        var index = Array.IndexOf(levels, currentScene);
        SceneManager.LoadScene(levels[index + 1]);
    }
}