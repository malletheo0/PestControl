using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlacePuls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 scale;
    public bool done = false;
    public bool bigDone = false;
    public float timer;
    void Start()
    {
        scale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            timer += Time.deltaTime*4;
        }
        timer += Time.deltaTime*4;
        if (done == false)
        {
            //scale.x = scale.y = Mathf.Sin(timer * 12) * 0.1f + 1.1f;

            scale.x = scale.y = ((-1f*(timer) * (timer) + 1f)*0.25f) + 1f;
            transform.localScale = scale;
            scale = transform.localScale;
            if (timer >= 1f)
            {
                done = true;
            }
            else
            {
                if (bigDone == true)
                {
                    if (scale.x <= 1.01)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                        done = true;
                    }
                }
            }
        }

    }

}
