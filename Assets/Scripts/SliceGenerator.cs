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

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Slice Generator Collided with " + other.gameObject.name);

        if (other.gameObject.name == "Peel")
        {
            GameObject slice = Instantiate(slicePrefab, GrabPosition.position, Quaternion.identity);
            slice.transform.parent = GrabPosition;
        }
    }
}
