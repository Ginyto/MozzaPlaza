using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public Transform GrabPosition;
    public bool isCooking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Oven Collided with " + other.gameObject.name);

        if (other.gameObject.name == "Pizza")
        {
            isCooking = true;

            other.gameObject.transform.position = GrabPosition.position;
            other.gameObject.transform.rotation = GrabPosition.rotation;
            other.gameObject.transform.parent = GrabPosition;
        }
    }
}
