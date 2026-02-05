using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool ranCourutine = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ranCourutine == false)
        {
            StartCoroutine(smoothFadeCourutine(Time.deltaTime, 2));
            ranCourutine = true;
        }
    }

    public  void smoothFade(float time,float timeMax)
    {
        Debug.Log("smoothFade I gång");
        transform.GetComponent<Image>().color = new Color(
        transform.GetComponent<Image>().color.r,
        transform.GetComponent<Image>().color.g,
        transform.GetComponent<Image>().color.b,
        (time/timeMax)*(time/timeMax));
    }


    IEnumerator smoothFadeCourutine(float time, float timeMax)
    {
        for (float i = 0; i < timeMax; i += Time.deltaTime)
        {
            smoothFade(time, timeMax);
            Debug.Log("smoothFadeCourutine igång");
            yield return null;
        }
    }
}
