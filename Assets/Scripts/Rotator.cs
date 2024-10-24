using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed;

    void Start()
    {
        speed = Random.Range(70f, 200f); // Set a random speed between 50 and 150
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime); //rotate the objects
    }
}

