using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public Transform GrabPosition;
    public bool isCooking;
    [SerializeField] private PizzaPeel pizzaPeel;
    public GameObject Led;

    public GameObject Pizza;

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
            Pizza = other.gameObject;
            isCooking = true;

            Pizza.transform.SetPositionAndRotation(GrabPosition.position, GrabPosition.rotation);
            Pizza.transform.parent = GrabPosition;

            StartCoroutine(Cooking(Pizza.GetComponent<Pizza>().cookingTime));

            Debug.Log("Pizza dans four");
        }
    }

    IEnumerator Cooking(int time)
    {
        Pizza.GetComponent<Pizza>().unCooked = true;

        Led.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.yellow, 0.5f);

        yield return new WaitForSeconds(time);

        Led.GetComponent<Renderer>().material.color = Color.red;

        Pizza.GetComponent<Pizza>().unCooked = false;
        Pizza.GetComponent<Pizza>().cooked = true;

        yield return new WaitForSeconds(5);

        Led.GetComponent<Renderer>().material.color = Color.black;
        Pizza.GetComponent<Pizza>().cooked = false;
        Pizza.GetComponent<Pizza>().overCooked = true;

    }
}
