using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Preview : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector2 mousePosition;
    Vector2 boxCastSize = new Vector2(1, 1);
    public bool inBlock = false;
    public bool leftClickPressed = false;
    public GameObject Block;
    public GameObject boxCollider;
    public PlayerInput playerInput;
    public InputAction placeAction;
    public GameObject gameManager;
    public LayerMask hitableLayers;
    void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerInput>();
        placeAction = playerInput.actions.FindAction("Place");
        placeAction.Enable();
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {


        if (placeAction.WasPressedThisFrame())
        {
            leftClickPressed = true;
        }
    }
    private void FixedUpdate()
    {
        if(gameManager.GetComponent<GameManager>().bottleSelected == true)
        {
            boxCastSize = new Vector2(1,0.35f);
        }
        else
        {
            boxCastSize = new Vector2(1,1);
        }
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = mousePosition;
        if(Physics2D.OverlapBox(transform.position, boxCastSize, 0, hitableLayers))
        {
            inBlock = true;
        }
        

        if (leftClickPressed)
        {
            if (inBlock == false)
            {
                Instantiate(Block, transform.position, Quaternion.identity.normalized);
                gameManager.GetComponent<GameManager>().blockSelected = false;
                gameManager.GetComponent<GameManager>().cloudSelected = false;
                gameManager.GetComponent<GameManager>().boxSelected = false;
                gameManager.GetComponent<GameManager>().bottleSelected = false;
                Destroy(gameObject);
            }
        }
        if(inBlock == false)
        {

            gameObject.GetComponent<Renderer>().material.color = new Color(0,1,0);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);

        }

        leftClickPressed = false;

        if (inBlock == true)
        {
            inBlock = false;
        }
    }






}
