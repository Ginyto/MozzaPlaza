using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPeel : MonoBehaviour
{
    public Transform GrabPosition;
    public bool isGrabbed;

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
        Debug.Log("Collided with " + other.gameObject.name);

        if (other.gameObject.name == "Pizza")
        {
            isGrabbed = true;
            other.gameObject.transform.position = GrabPosition.position;

            other.gameObject.transform.parent = GrabPosition;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
