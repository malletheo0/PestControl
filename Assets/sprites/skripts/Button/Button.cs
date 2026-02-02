using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Cloud;
    public Vector3 Position= new Vector3(1,1,1);
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnCloud()
    {
        Instantiate(Cloud, Position, Quaternion.identity.normalized);
    }
}
