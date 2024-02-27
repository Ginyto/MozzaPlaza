using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public List<GameObject> Margherita = new List<GameObject>();
    public List<GameObject> Hawaienne = new List<GameObject>();
    public List<GameObject> Oriental = new List<GameObject>();
    public List<GameObject> Reine = new List<GameObject>();
    public List<GameObject[]> Recipes = new List<GameObject[]>();

    public GameObject PizzaPrefab;
    public Transform PizzaSpawn;
    public GameObject Prepa;

    // Start is called before the first frame update
    void Start()
    {
        IntitialiseRecipes();
        Order();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IntitialiseRecipes()
    {
        Recipes.Add(Margherita.ToArray());
        Recipes.Add(Hawaienne.ToArray());
        Recipes.Add(Oriental.ToArray());
        Recipes.Add(Reine.ToArray());
    }

    public List<GameObject> SelectRandomRecipe()
    {
        int random = Random.Range(0, Recipes.Count);
        return new List<GameObject>(Recipes[random]);
    }

    public void Order()
    {

        GameObject pizza = Instantiate(PizzaPrefab, PizzaSpawn.position, Quaternion.identity);

        pizza.GetComponent<Pizza>().recipe = SelectRandomRecipe();

        pizza.name = "Pizza " + pizza.GetComponent<Pizza>().recipe[0].name;

        pizza.transform.SetParent(Prepa.transform);

    }


}