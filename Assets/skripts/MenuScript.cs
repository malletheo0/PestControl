using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    void Start()
    {
       
    }

    void Update()
    {
        
    }
    public void StartGame()
    {
        //SceneManager.LoadScene(""); i parantesen: sätt namnet på scenen. 
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
