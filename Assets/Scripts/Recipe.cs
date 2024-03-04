using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    public List<GameObject> Margherita = new List<GameObject>();
    public List<GameObject> Hawaienne = new List<GameObject>();
    public List<GameObject> Oriental = new List<GameObject>();
    public List<GameObject> Reine = new List<GameObject>();
    public List<GameObject> Vegetal = new List<GameObject>();
    public List<GameObject> Carnivore = new List<GameObject>();
    public List<GameObject> Royal = new List<GameObject>();

    public List<GameObject[]> Recipes = new List<GameObject[]>();
    public List<GameObject> RecipeImagesHolder = new List<GameObject>();
    public List<Sprite> RecipeImages = new List<Sprite>();

    public GameObject PizzaPrefab;
    public Transform PizzaSpawn;
    public GameObject Prepa;
    public int PizzaIndex = 0;

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
        Recipes.Add(Vegetal.ToArray());
        Recipes.Add(Carnivore.ToArray());
        Recipes.Add(Royal.ToArray());

    }

    public List<GameObject> SelectRandomRecipe()
    {

        PizzaIndex = Random.Range(0, Recipes.Count-1);
        ScreenOrder();

        return new List<GameObject>(Recipes[PizzaIndex]);
    }

    public void ScreenOrder()
    {
        foreach (GameObject image in RecipeImagesHolder)
        {
            if(image.GetComponent<SpriteRenderer>().sprite == null)
            {
                image.GetComponent<SpriteRenderer>().sprite = RecipeImages[PizzaIndex];
                break;
            }
        }
    }


    public void Order()
    {

        GameObject pizza = Instantiate(PizzaPrefab, PizzaSpawn.position, Quaternion.identity);

        pizza.GetComponent<Pizza>().recipe = SelectRandomRecipe();

        pizza.name = "Pizza " + RecipeImages[PizzaIndex].name;

        pizza.transform.SetParent(Prepa.transform);

    }


}
