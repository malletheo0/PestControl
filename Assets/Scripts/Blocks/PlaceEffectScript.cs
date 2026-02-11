using UnityEngine;

public class PlaceEffectScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip placeSound;
    void Start()
    {
        audioSource.PlayOneShot(placeSound);
    }

    void Update()
    {
        
    }
}
