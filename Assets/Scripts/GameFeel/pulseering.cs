using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class pulseering : MonoBehaviour
{
    bool mouseOver = false;
    public Vector3 scale;
    public Vector3 baseScale;

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
        if (mouseOver == true)
        {
            
            scale.x = scale.y = Mathf.Sin(Time.time * 3) * 0.1f + 1;
            transform.localScale = scale;
            transform.localScale = baseScale;
 
        }
        else
        {
            transform.localScale = baseScale;
        }
    
    
    }
    private void OnMouseOver()
    {
        mouseOver = true;
        Debug.Log("över");
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        Debug.Log("exit");
    }
}
