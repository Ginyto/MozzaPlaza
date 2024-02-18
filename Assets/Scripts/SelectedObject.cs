using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class SelectedObject : MonoBehaviour
{
    public Material OutlineRenderer;

    public GameObject Peel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Select();
    }

    public void Select()
    {
        if (Vector3.Distance(transform.position, Peel.transform.position) < 3f)
        {

            if(gameObject.GetComponent<Renderer>().materials.Length == 1)
            {
                gameObject.GetComponent<Renderer>().AddMaterial(OutlineRenderer);
            }

        }

        else
        {   
            if (gameObject.GetComponent<Renderer>().materials.Length > 1)
            {
                Debug.Log("material length: " + gameObject.GetComponent<Renderer>().materials.Length);
                gameObject.GetComponent<Renderer>().materials = new Material[] { gameObject.GetComponent<Renderer>().materials[0] };
            }
        }
    }
}
