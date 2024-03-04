using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    public Transform GrabPosition;
    public bool isCooking;
    [SerializeField] private PizzaPeel pizzaPeel;
    public GameObject Led;

    private Coroutine Lethimcook;

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

        if (other.gameObject.CompareTag("Pizza") && !pizzaPeel.hasPizzaLeft)
        {
            Pizza = other.gameObject;
            isCooking = true;

            Pizza.transform.SetPositionAndRotation(GrabPosition.position, GrabPosition.rotation);
            Pizza.transform.parent = GrabPosition;

            Lethimcook = StartCoroutine(Cooking());

            if (Pizza.GetComponent<Pizza>().cooked || Pizza.GetComponent<Pizza>().overCooked)
            {
                StopCoroutine(Lethimcook);
            }

            Debug.Log("Pizza dans four");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pizza"))
        {
            isCooking = false;
            Debug.Log("Pizza sortie du four");
        }
    }

    IEnumerator Cooking()
    {
        Pizza.GetComponent<Pizza>().unCooked = true;

        Led.GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.yellow, 0.5f);

        yield return new WaitForSeconds(Pizza.GetComponent<Pizza>().cookingTime);

        Led.GetComponent<Renderer>().material.color = Color.red;

        Pizza.GetComponent<Pizza>().unCooked = false;
        Pizza.GetComponent<Pizza>().cooked = true;

        yield return new WaitForSeconds(5);

        Led.GetComponent<Renderer>().material.color = Color.black;
        Pizza.GetComponent<Pizza>().cooked = false;
        Pizza.GetComponent<Pizza>().overCooked = true;

    }
}
