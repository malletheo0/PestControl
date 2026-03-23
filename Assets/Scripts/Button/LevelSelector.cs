using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public GameObject soundManager;
    public int levelUnlock;
    public AudioSource audioSource;
    public Image[] levelButtons;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager");
        levelUnlock = soundManager.GetComponent<SoundManagerScript>().highestLevelNumber;
        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelUnlock)
            {
                levelButtons[i].color = Color.gray;
            }
        }
        
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
