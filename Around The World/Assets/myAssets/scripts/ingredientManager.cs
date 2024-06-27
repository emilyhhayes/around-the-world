using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ingredientManager : MonoBehaviour
{
    public GameObject[] hideIngredients;

    [SerializeField] private recipeListSO recipeListSO;
    [SerializeField] public ingredientSO minceIngredientSO;

    private List<recipesSO> waitingRecipeSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4f;
    private int waitingRecipesMax = 1;
    public List<string> droppedIngredients = new List<string>();

    private void Awake()
    {
        waitingRecipeSOList = new List<recipesSO>();

        foreach (GameObject obj in hideIngredients)
        {
            obj.SetActive(false);
        }
    }


    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;


            if (waitingRecipeSOList.Count < waitingRecipesMax)
            {
                recipesSO waitingRecipeSO = recipeListSO.recipeSOList[Random.Range(0, recipeListSO.recipeSOList.Count)];
                Debug.Log(waitingRecipeSO.recipeName);


                for (int i=0; i < waitingRecipeSO.ingredientSOList.Count; i++)
                {
                    Debug.Log(waitingRecipeSO.ingredientSOList[i].ingredientName);
                }

                waitingRecipeSOList.Add(waitingRecipeSO);



            }
        }
    }

    public void addIngredients(string ingredientName)
    {
        droppedIngredients.Add(ingredientName);

        foreach (string droppedIngredientName in droppedIngredients)
        {
            Debug.Log("in here is" + droppedIngredientName);
        }

    }

    public void CheckIngredients()
    {
        foreach (recipesSO recipe in waitingRecipeSOList)
        {
            Debug.Log("checkingrecipe" +  recipe.recipeName);
            //List<string> missingIngredient = new List<string>();
            
            bool allMatch = true;

            for (int i = 0; i < recipe.ingredientSOList.Count; i++)
            {
                string recipeIngredient = recipe.ingredientSOList[i].ingredientName;

                if (!droppedIngredients.Contains(recipeIngredient))
                {
                    allMatch = false; break;
                    //missingIngredient.Add(recipeIngredient);
                }
            }

            if (allMatch)
            {
                Debug.Log("All dropped ingredients match the recipe: " + recipe.recipeName);
            }

            else
            {
                Debug.Log("Some dropped ingredients do not match the recipe: " + recipe.recipeName);

               // Debug.Log("Missing ingred");
                //foreach (string ingredient in missingIngredient)
               // {
              //      Debug.Log("hey"+ingredient);
               // }
            }
        }
    }


}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             