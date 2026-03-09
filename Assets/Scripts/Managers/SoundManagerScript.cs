using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManagerScript : MonoBehaviour
{
    public static SoundManagerScript Instance;
    public bool hasPlayed;
    public int levelNumber;
    public Scene level;
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

        
        if (levelNumber <= SceneManager.GetActiveScene().buildIndex)
        {
            levelNumber = SceneManager.GetActiveScene().buildIndex;
            hasPlayed = true;
        }
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
