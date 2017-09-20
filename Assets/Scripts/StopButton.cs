using UnityEngine;
using System.Collections;

public class StopButton : MonoBehaviour {

    private LevelManager levelManager;

    private void OnMouseDown()
    {
        levelManager.LoadLevel("01a Start");
    }

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
}
