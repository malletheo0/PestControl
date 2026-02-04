using Unity.Mathematics;
using UnityEngine;

public class pulseering : MonoBehaviour
{
    public Vector3 scale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        scale.x = scale.y = Mathf.Sin(Time.time*3)*0.1f + 1 ;
        transform.localScale = scale;
    }
}
