using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool blockSelected = false;
    public PlayerInput resetInput;
    public InputAction resetAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetAction = resetInput.actions.FindAction("Reset");
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
    }

    
}
