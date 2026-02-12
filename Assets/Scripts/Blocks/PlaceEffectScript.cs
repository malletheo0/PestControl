using UnityEngine;

public class PlaceEffectScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip placeSound;
    public ParticleSystem smoke;
    void Start()
    {
        audioSource.PlayOneShot(placeSound);
        Instantiate(smoke, transform.position, Quaternion.Euler(90,0,0));
    }

    void Update()
    {
        
    }
}
