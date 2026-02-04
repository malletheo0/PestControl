using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool blockSelected = false;
    public GameObject canvas;
    public GameObject player;
    public int cloudAmountMax;
    public int boxAmountMax;
    public int bottleAmountMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cloudAmountMax = canvas.GetComponent<Button>().cloudAmount;
        boxAmountMax = canvas.GetComponent<Button>().boxAmount;
        bottleAmountMax = canvas.GetComponent<Button>().bottleAmount;


    }

    // Update is called once per frame
    void Update()
    {
        if(1+1 ==2)
        {
            canvas.GetComponent<Button>().cloudAmount = cloudAmountMax;
            canvas.GetComponent<Button>().boxAmount = boxAmountMax;
            canvas.GetComponent<Button>().bottleAmount = bottleAmountMax;
        }
    }

    
}
