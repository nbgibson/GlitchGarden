using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public float autoLoadNextLevelAfter;

    private void Start()
    {
        if(autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Level auto load disabled. Use a number greater than 0 to enable.");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
            Debug.Log("Loading " + autoLoadNextLevelAfter.ToString());
        }
        
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
        Debug.Log("Loading level index " + (Application.loadedLevel + 1).ToString());
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
