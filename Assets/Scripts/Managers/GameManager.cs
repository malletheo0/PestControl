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
    public PlayerInput playerResetInput;
    public PlayerInput playerDeselectInput;
    public PlayerInput playerInput;

    public InputAction resetAction;
    public InputAction deselectAction;
    public InputAction escapeAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetAction = playerResetInput.actions.FindAction("Reset");
        deselectAction = playerDeselectInput.actions.FindAction("Deselect");
        escapeAction = playerInput.actions.FindAction("Exit");

        deselectAction.Enable();
        resetAction.Enable();
        escapeAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if(resetAction.WasReleasedThisFrame())
        {
            int id = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(id);
        }

        if(escapeAction.WasPressedThisFrame())
        {
            SceneManager.LoadScene(0);
        }

        if(deselectAction.WasPressedThisFrame())
        {
            GameObject block = GameObject.FindGameObjectWithTag("Preview");
            if(cloudSelected == true)
            {
                Destroy(block);
                blockSelected = false;
                cloudSelected = false;
                canvas.GetComponent<Button>().cloudAmount += 1;
                canvas.GetComponent<Button>().cloudButtonText.text = canvas.GetComponent<Button>().cloudAmount.ToString();
            }
            else if(boxSelected == true)
            {
                Destroy(block);
                blockSelected = false;
                boxSelected = false;
                canvas.GetComponent<Button>().boxAmount += 1;
                canvas.GetComponent<Button>().boxButtonText.text = canvas.GetComponent<Button>().boxAmount.ToString();
            }
            else if(bottleSelected == true)
            {
                Destroy(block);
                blockSelected = false;
                bottleSelected = false;
                canvas.GetComponent<Button>().bottleAmount += 1;
                canvas.GetComponent<Button>().bottleButtonText.text = canvas.GetComponent<Button>().bottleAmount.ToString();

            }
        }

        
        
    }

}
