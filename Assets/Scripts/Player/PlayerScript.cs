using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public PlayerInput playerInput;
    InputAction moveAction;
    InputAction jumpAction;
    public Vector3 velocity;
    public Transform topLeft;
    public Transform topRight;
    public Transform midLeft;
    public Transform midRight;
    public Transform botLeft;
    public Transform botRight;
    public bool isGrounded;
    bool hasJumped = false;
    public LayerMask groundMask;
    public Animator animator;
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
        //transform.Translate(inputVector * 3 * Time.deltaTime);
        velocity.x = inputVector.x * 5f;

        if (jumpAction.WasPressedThisFrame() && isGrounded == true)
        {
            hasJumped = true;
        }

        animator.SetFloat("VelocityX", Mathf.Abs(velocity.x));
        animator.SetBool("IsGrounded", isGrounded);
    }
    private void FixedUpdate()
    {
        if(hasJumped)
        {
            velocity.y = 12;
            isGrounded = false;
            hasJumped = false;
        }
        if (isGrounded)
        {
            velocity.y = 0f;

            RaycastHit2D hit = Physics2D.Raycast(botLeft.position + Vector3.right * 0.01f, Vector2.down, 0.01f, groundMask);
            RaycastHit2D hit2 = Physics2D.Raycast(botRight.position + Vector3.left * 0.01f, Vector2.down, 0.01f, groundMask);
            if (!hit && !hit2)
            {
                isGrounded = false;
            }
        }

        if (velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            RaycastHit2D hit = Physics2D.Raycast(topRight.position + Vector3.down * 0.01f, Vector2.right, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask);
            RaycastHit2D hit2 = Physics2D.Raycast(botRight.position + Vector3.up * 0.01f, Vector2.right, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask);
            RaycastHit2D hit3 = Physics2D.Raycast(midRight.position, Vector2.right, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask);
            if (hit)
            {
                velocity.x = hit.distance / Time.fixedDeltaTime;
            }
            else if (hit2)
            {
                velocity.x = hit.distance / Time.fixedDeltaTime;
            }
            else if (hit3)
            {
                velocity.x = hit.distance / Time.fixedDeltaTime;
            }

        }
        if (velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            RaycastHit2D hit = Physics2D.Raycast(topLeft.position + Vector3.down * 0.01f, Vector2.left, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask);
            RaycastHit2D hit2 = Physics2D.Raycast(botLeft.position + Vector3.up * 0.01f, Vector2.left, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask);
            RaycastHit2D hit3 = Physics2D.Raycast(midLeft.position, Vector2.left, Mathf.Abs(velocity.x * Time.fixedDeltaTime), groundMask);
            if (hit)
            {
                    velocity.x = hit.distance / Time.fixedDeltaTime;
            }
            else if (hit2)
            {
                    velocity.x = hit.distance / Time.fixedDeltaTime;
            }
            else if (hit3)
            {
                velocity.x = hit.distance / Time.fixedDeltaTime;
            }
        }
        if (velocity.y > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(topLeft.position + Vector3.right * 0.01f, Vector2.up, Mathf.Abs(velocity.y * Time.fixedDeltaTime), groundMask);
            RaycastHit2D hit2 = Physics2D.Raycast(topRight.position + Vector3.left * 0.01f, Vector2.up, Mathf.Abs(velocity.y * Time.fixedDeltaTime), groundMask);
            if (hit)
            {
                velocity.y = 0;
            }
            else if (hit2)
            {
                velocity.y = 0;
            }
        }
        if (isGrounded == false)
        {
            if (velocity.y < 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(botLeft.position + Vector3.right * 0.01f, Vector2.down, Mathf.Abs(velocity.y * Time.fixedDeltaTime), groundMask);
                RaycastHit2D hit2 = Physics2D.Raycast(botRight.position + Vector3.left * 0.01f, Vector2.down, Mathf.Abs(velocity.y * Time.fixedDeltaTime), groundMask);
                if (hit)
                {
                    isGrounded = true;
                    velocity.y = hit.distance / Time.fixedDeltaTime * -1;     
                }
                else if (hit2)
                {
                        isGrounded = true;
                        velocity.y = hit2.distance / Time.fixedDeltaTime * -1;
                }

            }

            if (isGrounded == false)
            {
                velocity.y -= 30f * Time.fixedDeltaTime;
            }
        }


        transform.position += velocity * Time.fixedDeltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.CompareTag("Finish"))
        {
            StartCoroutine(DelayGoal());
            velocity.x = 0;
            velocity.y = 0;
        }
    }
    IEnumerator DelayGoal()
    {
        for (float i = 0; i < 1.5f; i+=Time.deltaTime)
        {
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
