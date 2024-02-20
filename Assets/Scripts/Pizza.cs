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

    public void OnTriggerEnter(Collider other)
    {
        IngredientAdded(other);
    }

    public void IngredientAdded(Collider ingredient)
    {
        if (ingredient.gameObject.name != "Table"){

            Debug.Log(ingredient.name + " is on the pizza!");

            if(ingredient.gameObject.CompareTag("Ingredient")){

                Rigidbody rb = ingredient.gameObject.GetComponent<Rigidbody>();

                rb.isKinematic = true;

                ingredient.gameObject.transform.parent = gameObject.transform;
            }
        }

    }

    
}
