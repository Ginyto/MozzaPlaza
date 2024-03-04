using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public Recipe RecipeManager;
    public GameObject Pizza;

    public PizzaPeel pizzaPeel;

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
        /*Debug.Log("Oven Collided with " + other.gameObject.name);*/

        if (other.gameObject.CompareTag("Pizza") && !pizzaPeel.hasPizzaLeft)
        {
            Pizza = other.gameObject;

            Pizza.transform.SetPositionAndRotation(GrabPosition.position, GrabPosition.rotation);
            Pizza.transform.parent = GrabPosition;

            RecipeManager.RecipeImagesHolder[Pizza.GetComponent<Pizza>().Index].SetActive(false);

            Destroy(Pizza);

            RecipeManager.Order();

        }
    }
}
