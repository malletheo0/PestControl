using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject startButton;
    public bool hasPressed;
    public GameObject soundManager;
    public AudioSource audioSource;
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager");
        hasPressed = soundManager.GetComponent<SoundManagerScript>().hasPlayed;
        audioSource = soundManager.GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("keepVolume");

        if (GameObject.FindGameObjectWithTag("Canvas") != null)
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("keepVolume");

        //Debug.Log(PlayerPrefs.GetFloat("keepVolume"));
    }


    void Update()
    {
        if (hasPressed)
        {
            Destroy(startButton);
        }
    }
    public void StartGame()
    {
        PlayerPrefs.SetFloat("keepVolume", audioSource.volume);
        Debug.Log(audioSource.volume);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Destroy(startButton);
        hasPressed = true;
        soundManager.GetComponent<SoundManagerScript>().hasPlayed = true;
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void Continue()
    {
        if(GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>() != null)
        {
            PlayerPrefs.SetFloat("keepVolume", audioSource.volume);
            SceneManager.LoadScene(GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>().levelNumber);
        }
    }
}
