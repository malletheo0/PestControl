using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    public GameObject soundManager;
    public int levelUnlock;
    public AudioSource audioSource;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager");
        levelUnlock = soundManager.GetComponent<SoundManagerScript>().highestLevelNumber;
        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int levelNumber)
    {
        if (levelNumber <= levelUnlock)
        {
            PlayerPrefs.SetFloat("keepVolume", audioSource.volume);
            SceneManager.LoadScene(levelNumber);
        }
    }
}
