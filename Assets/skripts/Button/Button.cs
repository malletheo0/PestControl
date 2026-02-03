using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Button : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Cloud;
    public GameObject Box;
    public GameObject Bottle;
    public int cloudAmount;
    public int boxAmount;
    public int bottleAmount;

    public TextMeshProUGUI cloudButtonText;
    public TextMeshProUGUI boxButtonText;
    public TextMeshProUGUI bottleButtonText;
    Vector2 mousePosition;

    void Start()
    {

        cloudButtonText.text = cloudAmount.ToString();
        boxButtonText.text = boxAmount.ToString();
        bottleButtonText.text = bottleAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
    }

    public void SpawnCloud()
    {
        if (cloudAmount >= 0.1)
        {
            Instantiate(Cloud, mousePosition, Quaternion.identity.normalized);
            cloudAmount -= 1;
            cloudButtonText.text = cloudAmount.ToString();
        }
    }

    public void SpawnBox()
    {
        if (boxAmount >= 0.1)
        {
            Instantiate(Box, mousePosition, Quaternion.identity.normalized);
            boxAmount -= 1;
            boxButtonText.text = boxAmount.ToString();
        }
    }

    public void SpawnBottle()
    {
        if (bottleAmount >= 0.1)
        {
            Instantiate(Bottle, mousePosition, Quaternion.identity.normalized);
            bottleAmount -= 1;
            bottleButtonText.text = bottleAmount.ToString();
        }
    }
}
