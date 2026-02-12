using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static SoundManagerScript Instance;
    void Start()
    {

        DontDestroyOnLoad(gameObject.transform);
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
