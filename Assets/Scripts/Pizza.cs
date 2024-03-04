using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public bool unCooked = false;
    public bool cooked = false;
    public bool overCooked = false;
    public List<GameObject> ingredients = new List<GameObject>();
    public List<GameObject> recipe = new List<GameObject>();
    public bool isMatch = false;
    public int cookingTime = 0;
    private bool done = false;
    public GameObject PizzaIndicator;


    // Start is called before the first frame update
    void Start()
    {
        PizzaIndicator = GameObject.Find("Indicator");
    }

    // Update is called once per frame
    void Update()
    {
        IsMatch();
    }

    public void IngredientsOnPizza(GameObject ingredient)
    {
        ingredients.Add(ingredient);
    }

    public void RenameIngredients(List<GameObject> list)
    {
        string[] ingredientsList = { "champi", "chorizo", "jambon", "mozza", "pina", "tomato", "olive"};

        if (list.Count > 0)
        {
            foreach (GameObject ingredient in list)
            {
                foreach (string name in ingredientsList)
                {
                    if (ingredient.name.Contains(name))
                    {
                        ingredient.name = name;
                        cookingTime += (int)(ingredient.transform.localScale.x) / 2;
                    }
                }
            }
        }
    }

    public void SortPizza()
    {
        RenameIngredients(ingredients);
        RenameIngredients(recipe);

        ingredients.Sort((x, y) => x.name.CompareTo(y.name));
        recipe.Sort((x, y) => x.name.CompareTo(y.name));
    }

    public void IsMatch()
    {
        if (ingredients.Count == recipe.Count && !done)
        {
            SortPizza();

            isMatch = true;

            for (int i = 0; i < ingredients.Count; i++)
            {
                if (ingredients[i].name != recipe[i].name)
                {
                    isMatch = false;
                    break;
                }
            }

            if (isMatch)
            {
                Debug.Log("Match");
                PizzaIndicator.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                Debug.Log("No Match ingredients are different from recipe");
                PizzaIndicator.GetComponent<Renderer>().material.color = Color.red;
            }

            cookingTime /= 2;
            done = true;
        }
    }
}
