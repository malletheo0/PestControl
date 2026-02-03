using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public PlayerInput playerInput;
    InputAction moveAction;
    InputAction jumpAction;
    public Vector3 velocity;
    void Start()
    {
        moveAction = playerInput.actions.FindAction("Move");
        jumpAction = playerInput.actions.FindAction("Jump");
        moveAction.Enable();
        jumpAction.Enable();

    }
    void Update()
    {
        Vector3 inputVector = moveAction.ReadValue<Vector2>();
        transform.Translate(inputVector * 3 * Time.deltaTime);

        if (jumpAction.WasPressedThisFrame())
        {
            velocity.y += 5;
        }
        else
        {
            velocity.y = 0; 
        }
        velocity.y -= 5;
        transform.position += velocity * Time.deltaTime;
    }
}
