using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class pulseering : MonoBehaviour
{
    Vector3 mousePosition;
    public Vector3 scale;
    public Vector3 baseScale;
    public Vector3 position;
    public Vector2 size;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scale = transform.localScale;
        size = gameObject.GetComponent<RectTransform>().sizeDelta;
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
        if (mousePosition.x >= (position.x - (size.x/2)) && mousePosition.x <= (position.x + (size.x / 2)))
        {
            if (mousePosition.y >= (position.y - (size.y / 2)) && mousePosition.y <= (position.y + (size.y / 2)))
            {
                scale.x = scale.y = Mathf.Sin(Time.time * 3) * 0.1f + 1.1f;
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
}
