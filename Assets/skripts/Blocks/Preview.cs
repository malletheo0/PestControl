using UnityEngine;
using UnityEngine.InputSystem;

public class Preview : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector2 mousePosition;
    public bool inBlock = false;
    public GameObject Block;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = mousePosition;

        

    }

    void OnMouseDown()
    {
        if(inBlock == false)
        {
            Instantiate(Block,transform.position,Quaternion.identity.normalized);
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        inBlock = true;
        //ändra namn på bool om det behålls så här
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        inBlock = false;
    }
}
