using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaPeel : MonoBehaviour
{
    public Transform GrabPosition;
    public bool isPizzaOn = false;
    public bool hasPizzaLeft = false;

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
        /*Debug.Log("Peel Collided with " + other.gameObject.name);*/

        if (other.gameObject.CompareTag("Four") && !isPizzaOn) hasPizzaLeft = true;
        if (other.gameObject.CompareTag("Pizza") && !isPizzaOn)
        {
            other.gameObject.transform.SetPositionAndRotation(
                GrabPosition.position,
                GrabPosition.rotation
                );

            AttachIngredients ingScript = other.gameObject.GetComponent<AttachIngredients>();
            ingScript.enabled = false;

            other.gameObject.transform.parent = GrabPosition;

            isPizzaOn = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Four"))
        {
            isPizzaOn = IsPizzaGosse();
            Debug.Log(isPizzaOn);
            StartCoroutine(ChangeLeftOven(false));
        }
    }

    private IEnumerator ChangeLeftOven(bool value)
    {
        yield return new WaitForSeconds(0.5f);
        hasPizzaLeft = value;
    }

    private bool IsPizzaGosse()
    {
        bool isPizzaGosse = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.CompareTag("Pizza")) isPizzaGosse = true;
        }
        return isPizzaGosse;
    }
}
