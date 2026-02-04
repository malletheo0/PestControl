using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool blockSelected = false;
    public bool cloudSelected = false;
    public bool boxSelected = false;
    public bool bottleSelected = false;

    public GameObject canvas;
    public PlayerInput playerInput;
    public InputAction resetAction;
    public InputAction deselectAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetAction = playerInput.actions.FindAction("Reset");
        deselectAction = playerInput.actions.FindAction("Deselect");
        deselectAction.Enable();
        resetAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(resetAction.WasReleasedThisFrame())
        {
            int id = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(id);
        }

        if(deselectAction.WasPressedThisFrame())
        {
            GameObject block = GameObject.FindGameObjectWithTag("Box");
            if(cloudSelected == true)
            {
                Destroy(block);
                cloudSelected = false;
                canvas.GetComponent<Button>().cloudAmount += 1;
            }
            else if(boxSelected == true)
            {
                Destroy(block);
                boxSelected = false;
                canvas.GetComponent<Button>().boxAmount += 1;
            }
            else if(bottleSelected == true)
            {
                Destroy(block);
                bottleSelected = false;
                canvas.GetComponent<Button>().bottleAmount += 1;

            }
        }
    }

    
}
