using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject startButton;
    public bool hasPressed;
    public GameObject soundManager;
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SoundManager");
        hasPressed = soundManager.GetComponent<SoundManagerScript>().hasPlayed;
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
            SceneManager.LoadScene(GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>().levelNumber);
        }
    }
}
