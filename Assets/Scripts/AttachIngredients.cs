using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachIngredients : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        IngredientAdded(other);
    }

    public void IngredientAdded(Collider ingredient)
    {
        if (ingredient.gameObject.name != "Table")
        {
            Debug.Log(ingredient.name + " is on the pizza!");

            if(ingredient.gameObject.CompareTag("Ingredient"))
            {

                Rigidbody rb = ingredient.gameObject.GetComponent<Rigidbody>();
                Destroy(rb);

                XRGrabInteractable grabScript = ingredient.gameObject.GetComponent<XRGrabInteractable>();
                grabScript.enabled = false;

                ingredient.gameObject.transform.parent = gameObject.transform;
            }
        }

    }

    
}
