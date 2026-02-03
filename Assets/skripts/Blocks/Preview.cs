using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Preview : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector2 mousePosition;
    public bool inBlock = false;
    public GameObject Block;
    public PlayerInput playerInput;
    public InputAction placeAction;
    public Color originalColor;
    public GameObject gameManager;
    void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerInput>();
        placeAction = playerInput.actions.FindAction("Place");
        placeAction.Enable();
        originalColor = gameObject.GetComponent<SpriteRenderer>().color;
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = mousePosition;


        if (placeAction.WasPressedThisFrame())
        {
            if (inBlock == false)
            {
                Instantiate(Block, transform.position, Quaternion.identity.normalized);
                gameManager.GetComponent<GameManager>().blockSelected = false;
                Destroy(gameObject);
            }
        }
    }




    public void OnCollisionStay2D(Collision2D collision)
    {
        inBlock = true;
        //ändra namn på bool om det behålls så här
        gameObject.GetComponent<Renderer>().material.color = new Color(365,0,0);
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        inBlock = false;
        gameObject.GetComponent<Renderer>().material.color = originalColor;
    }


}
