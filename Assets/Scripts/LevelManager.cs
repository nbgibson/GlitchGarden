using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public float autoLoadNextLevelAfter;

    private void Start()
    {
        if(autoLoadNextLevelAfter == 0)
        {
            Debug.Log("Level auto load disabled.");
        }
        Invoke("LoadNextLevel", autoLoadNextLevelAfter);
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for " + name);
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
