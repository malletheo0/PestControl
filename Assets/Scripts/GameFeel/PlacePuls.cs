using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlacePuls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 scale;
    public bool done = false;
    public bool bigDone = false;
    void Start()
    {
        scale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (done == false)
        {
            scale.x = scale.y = Mathf.Sin(Time.time * 3) * 0.1f + 1.1f;
            transform.localScale = scale;
            scale = transform.localScale;
            if (scale.x >= 1.19f)
            {
                bigDone = true;
            }
            else
            {
                if (bigDone == true)
                {
                    if (scale.x <= 1)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        done = true;
                    }
                }
            }
        }

    }

}
