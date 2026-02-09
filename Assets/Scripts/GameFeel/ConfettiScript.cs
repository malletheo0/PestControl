using UnityEngine;

public class ConfettiScript : MonoBehaviour
{
    public ParticleSystem Confetti;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject)
        {
            Instantiate(Confetti, transform.position, Quaternion.identity);
        }
    }
}
