using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    public GameObject soundManager;
    public int levelUnlock;

    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager");
        levelUnlock = soundManager.GetComponent<SoundManagerScript>().highestLevelNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int levelNumber)
    {
        if (levelNumber <= levelUnlock)
        {
            SceneManager.LoadScene(levelNumber);
        }
    }
}
