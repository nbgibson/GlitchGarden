using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public float levelSeconds = 100;

    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;

	// Use this for initialization
	void Start ()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        FindYouWin();
        winLabel.SetActive(false);
    }

    private void FindYouWin()
    {
        winLabel = GameObject.Find("You Win");
        if (!winLabel)
        {
            Debug.LogWarning("No You Win object found.");
        }
    }

    // Update is called once per frame
    void Update () {
        slider.value = 1 - (Time.timeSinceLevelLoad / levelSeconds);

        bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
        if(timeIsUp && !isEndOfLevel)
        {
            HandleWinCondition();
        }
    }

    private void HandleWinCondition()
    {
        DestroyAllTaggedObjects("destroyOnWin");
        winLabel.SetActive(true);
        audioSource.Play();
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }

    void DestroyAllTaggedObjects(string tag)
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag(tag);

        foreach(GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }
}
