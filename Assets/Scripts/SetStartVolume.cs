using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager)
        {            
            float volume = PlayerPrefsManager.GetMasterVolume();
            musicManager.ChangeVolume(volume);
            Debug.Log("Setting volume to saved value: " + volume);
        }
        else
        {
            Debug.LogWarning("No music manager fround in Start Scene, can't set volume.");
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
