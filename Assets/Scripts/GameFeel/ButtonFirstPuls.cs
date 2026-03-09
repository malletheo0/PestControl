using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonFirstPuls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 scale;
    public Vector3 baseScale;
    public Vector3 position;
    public Vector2 size;
    public bool clicked = false;
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
        position = transform.position;
        if (clicked == false)
        {
            scale.x = scale.y = Mathf.Sin(Time.time * 3) * 0.2f + 1.1f;
            transform.localScale = scale;
            scale = transform.localScale;
        }
        else 
        {
        transform.localScale = baseScale;
        scale = baseScale;
        }   
        
    }
}
