using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceGenerator : MonoBehaviour
{
    public GameObject slicePrefab;
    public Transform GrabPosition;

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
        if (other.gameObject.name != "Table")
        {
            Debug.Log(gameObject.name + " with " + other.gameObject.name);
        }

        if (other.gameObject.name == "Peel")
        {
            Debug.Log("Generating Slice");
            GameObject slice = Instantiate(slicePrefab, GrabPosition.position, Quaternion.identity);
        }
    }
}
