using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision other)
    {
        IngredientAdded(other);
    }

    public void IngredientAdded(Collision other)
    {
        GameObject ingredient = other.gameObject;

        if (ingredient.name != "Table"){

            Debug.Log(ingredient.name + " is on the pizza!");

            if (ingredient.CompareTag("Ingredient"))
            {
                Rigidbody rb = ingredient.GetComponent<Rigidbody>();

                rb.useGravity = false;
                rb.isKinematic = true;

                ingredient.transform.parent = gameObject.transform;

            }
        }

    }

    
}
