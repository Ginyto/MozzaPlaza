using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public Transform GrabPosition;
    public bool isCooking;
    [SerializeField] private PizzaPeel pizzaPeel;

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

        if (other.gameObject.CompareTag("Pizza") && !pizzaPeel.hasPizzaLeftOven)
        {
            isCooking = true;

            other.gameObject.transform.SetPositionAndRotation(GrabPosition.position, GrabPosition.rotation);
            other.gameObject.transform.parent = GrabPosition;

            Debug.Log("Pizza dans four");
        }
    }
}
