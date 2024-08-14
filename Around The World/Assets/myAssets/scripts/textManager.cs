using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class textManager : MonoBehaviour
{
  
    public TextMeshProUGUI recipeNameText; // Assign this in the Unity Editor
    private ingredientManager ingredientManager;

    void Start()
    {
        // Find the ingredientManager instance in the scene
        ingredientManager = ingredientManager.instance;

        // Print the recipe name in the console
        Debug.Log(ingredientManager.GetCurrentRecipeName());

        // Display the recipe name in the UI Text component (if any)
        recipeNameText.text = ingredientManager.GetCurrentRecipeName();
    } 
}
