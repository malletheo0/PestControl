using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManagerScript : MonoBehaviour
{
    public static SoundManagerScript Instance;
    public bool hasPlayed;
    public int levelNumber;
    public int highestLevelNumber;
    public Scene level;
    public AudioSource audioSource;
    public Slider musicSlider;
    public GameObject canvas;
    void Start()
    {
        DontDestroyOnLoad(gameObject.transform);
    }
    private void Update()
    {
        if (GetComponent<MenuScript>() != null)
        {
            if (GetComponent<MenuScript>().hasPressed)
            {
                hasPlayed = true;
            }
        }
        //musicSlider.value = audioSource.volume;
        audioSource.volume = GameObject.FindGameObjectWithTag("Canvas").GetComponent<AudioSource>().volume;
    }

    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            levelNumber = SceneManager.GetActiveScene().buildIndex;
        }

        if (levelNumber >= highestLevelNumber)
        {
            highestLevelNumber = levelNumber;
        }
        hasPlayed = true;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
    }

    public void UpdateVolume(float volume)
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
