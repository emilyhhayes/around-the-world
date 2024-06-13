using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkRecipe : MonoBehaviour
{
     private List<ingredientSO> ingredientsInBowl = new List<ingredientSO>();


    private void OnTriggerEnter(Collider other)

    {

        ingredientObject ingredient = other.GetComponent<ingredientObject>();

        if (ingredient != null)

        {

            ingredientsInBowl.Add(ingredient.ingredientData);

            Debug.Log(ingredient.ingredientData.ingredientName + " added to the bowl.");

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
