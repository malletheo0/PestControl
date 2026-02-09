using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class pulseering : MonoBehaviour
{
    Vector3 mousePosition;
    public Vector3 scale;
    public Vector3 baseScale;
    public Vector3 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scale = transform.localScale;
        baseScale = scale;

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        mousePosition = Mouse.current.position.ReadValue();
        position = transform.position;
        if (mousePosition.x >= (position.x -= 75f) && mousePosition.x <= (position.x += 130f))
        {
            if (mousePosition.y >= (position.y -= 70f) && mousePosition.y <= (position.y += 140f))
            {
                scale.x = scale.y = Mathf.Sin(Time.time * 3) * 0.125f + 1.1f;
                transform.localScale = scale;
                scale = transform.localScale;
            }
            else
            {
                transform.localScale = baseScale;
                scale = baseScale;
            }
        }
        else
        {
            transform.localScale = baseScale;
            scale = baseScale;
        }
    
    
    }
    private void OnMouseOver()
    {
        
    }
}
