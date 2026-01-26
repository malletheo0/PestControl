using UnityEngine;

public class playermovment : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        // Check for input
        if (Input.GetKey(KeyCode.W))
            moveY = 1f;
        if (Input.GetKey(KeyCode.S))
            moveY = -1f;
        if (Input.GetKey(KeyCode.A))
            moveX = -1f;
        if (Input.GetKey(KeyCode.D))
            moveX = 1f;

        // Normalize movement vector to prevent faster diagonal movement
        Vector3 move = new Vector3(moveX, moveY, 0f).normalized;

        // Move the player
        transform.position += move * moveSpeed * Time.deltaTime;
    }
}