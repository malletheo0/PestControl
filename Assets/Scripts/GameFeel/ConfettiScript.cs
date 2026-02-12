using UnityEngine;

public class ConfettiScript : MonoBehaviour
{
    public ParticleSystem Confetti;
    public AudioSource audioSource;
    public AudioClip yaaySound;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject)
        {
            if (collision.gameObject.tag == "Player")
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                Instantiate(Confetti, pos, Quaternion.identity);
                audioSource.PlayOneShot(yaaySound);
            }
        }
    }
}
