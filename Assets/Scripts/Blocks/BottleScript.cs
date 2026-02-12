using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BottleScript : MonoBehaviour
{
    public bool isUnder = false;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip breakSound;
    void Start()
    {
        
    }
    void Update()
    {
        animator.SetBool("IsUnder", isUnder);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //starta animation som sedan anropar ett animation event för att kopla till methoden för att förstöra
        isUnder = true;

    }

    public void DestroyGameObject()
    {
        //om partikel skapa här
        Destroy(gameObject);
    }

    public void BreakingSound()
    { 
        audioSource.PlayOneShot(breakSound);
    }

}
