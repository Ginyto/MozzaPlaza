using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    [SerializeField] private bool unCooked = false;
    [SerializeField] private bool cooked = false;
    [SerializeField] private bool overCooked = false;
    public List<GameObject> ingredients = new List<GameObject>();
    public List<GameObject> recipe = new List<GameObject>();
    public bool isMatch = false;
    public int cookingTime = 0;
    private bool done = false;


    // Start is called before the first frame update
    void Start()
    {

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
            }
            else
            {
                Debug.Log("No Match ingredients are different from recipe");
            }

            cookingTime /= 2;
            done = true;
        }
    }
}
