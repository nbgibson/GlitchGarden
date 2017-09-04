using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

    public Slider volumeSlider, difficultySlider;
    public LevelManager levelManager;

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        Debug.Log(musicManager);
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.ChangeVolume(volumeSlider.value);
	}

    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        Debug.Log("Setting master volume to: " + volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);
        Debug.Log("Setting difficulty to: " + difficultySlider.value);
        levelManager.LoadLevel("01a Start");
    }

    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2f;
    }
}
