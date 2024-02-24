using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPeel : MonoBehaviour
{
    public Transform GrabPosition;
    public bool isGrabbable = true;

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
        Debug.Log("Peel Collided with " + other.gameObject.name);

        if (other.gameObject.CompareTag("Pizza") && isGrabbable)
        {
            other.gameObject.transform.SetPositionAndRotation(
                GrabPosition.position,
                new(
                    other.gameObject.transform.rotation.x,
                    other.gameObject.transform.rotation.y,
                    GrabPosition.rotation.z,
                    Quaternion.identity.w
                ));

            AttachIngredients ingScript = other.gameObject.GetComponent<AttachIngredients>();
            ingScript.enabled = false;

            other.gameObject.transform.parent = GrabPosition;

            if (other.gameObject.CompareTag("Four"))
            {
                isGrabbable = false;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Four"))
        {
            isGrabbable = true;
        }
    }
}
