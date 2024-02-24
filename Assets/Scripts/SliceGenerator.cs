using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceGenerator : MonoBehaviour
{
    [SerializeField] private GameObject slicePrefab;
    [SerializeField] private int nbObjets;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private Transform spawnPoint3;
    private Transform[] spawnList;

    public Transform RandomSpawn()
    {
        int index = Random.Range(1, spawnList.Length) - 1;
        return spawnList[index];
    }


    void Start()
    {
        nbObjets += transform.childCount;
        spawnList = new Transform[] { spawnPoint1, spawnPoint2, spawnPoint3 };
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= nbObjets)
        {
            while (transform.childCount != nbObjets)
            {
                Instantiate(slicePrefab, RandomSpawn().position, Quaternion.identity, transform);
            }
        }
    }

/*    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Table")
        {
            Debug.Log(gameObject.name + " with " + other.gameObject.name);
        }

        if (other.gameObject.name == "Peel")
        {
            // Debug.Log("Generating Slice");
            GameObject slice = Instantiate(slicePrefab, GrabPosition.position, Quaternion.identity);
            slice.transform.parent = gameObject.transform;
        }
    }*/
}
