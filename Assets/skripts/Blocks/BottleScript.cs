using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BottleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //starta animation som sedan anropar ett animation event för att kopla till methoden för att förstöra
    }

    public void DestroyGameObject()
    {
        //om partikel skapa här
        Destroy(gameObject);
    }
}
