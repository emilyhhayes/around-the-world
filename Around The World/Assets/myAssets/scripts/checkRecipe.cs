using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkRecipe : MonoBehaviour
{
     private List<ingredientSO> ingredientsInBowl = new List<ingredientSO>();


    private void OnTriggerEnter(Collider other)
    {
        IngredientObject ingredient = other.GetComponent<IngredientObject>();
        if (ingredient != null)
        {
            ingredientsInBowl.Add(ingredient.ingredientSO);
            Debug.Log(ingredient.ingredientSO.ingredientName + " added to the bowl.");
        }
    }

     public bool CheckRecipe(recipesSO recipe)
    {
        if (ingredientsInBowl.Count != recipe.ingredientSOList.Count)
        {
            return false;
        }

        foreach (var ingredient in recipe.ingredientSOList)
        {
            if (!ingredientsInBowl.Contains(ingredient))
            {
                return false;
            }
        }
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
