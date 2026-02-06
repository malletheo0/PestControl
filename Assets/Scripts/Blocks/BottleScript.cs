using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BottleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isUnder = false;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
