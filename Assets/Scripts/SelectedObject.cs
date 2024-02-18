using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class SelectedObject : MonoBehaviour
{
    public Material OutlineRenderer;
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
        GameObject target = other.gameObject;

        if (target.GetComponent<Renderer>().materials.Length == 1)
        {
            target.GetComponent<Renderer>().AddMaterial(OutlineRenderer);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        GameObject target = other.gameObject;

        if (target.GetComponent<Renderer>().materials.Length > 1)
        {
            target.GetComponent<Renderer>().materials = new Material[] { target.GetComponent<Renderer>().materials[0] };
        }
    }
}
