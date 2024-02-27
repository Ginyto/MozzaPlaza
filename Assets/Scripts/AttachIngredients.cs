using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class AttachIngredients : MonoBehaviour
{
    public void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        IngredientAdded(other);
    }

    public void IngredientAdded(Collider ingredient)
    {
        if (ingredient.gameObject.name != "Table")
        {
            Debug.Log(ingredient.name + " is on the pizza!");

            if (ingredient.gameObject.CompareTag("Ingredient"))
            {
                Rigidbody rb = ingredient.gameObject.GetComponent<Rigidbody>();

                XRGrabInteractable grabScript = ingredient.gameObject.GetComponent<XRGrabInteractable>();
                XRGeneralGrabTransformer grabTransformer = ingredient.gameObject.GetComponent<XRGeneralGrabTransformer>();

                grabScript.enabled = false;
                grabTransformer.enabled = false;

                Destroy(grabScript);
                Destroy(grabTransformer);
                Destroy(rb);

                ingredient.gameObject.transform.parent = gameObject.transform;

                GetComponent<Pizza>().IngredientsOnPizza(ingredient.gameObject);
            }
        }

    }

    
}
