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


                foreach ( in waitingRecipeSOList)
                {

                }


                Debug.Log(waitingRecipeSO.ingredientSOList[0].ingredientName);
                Debug.Log(waitingRecipeSO.ingredientSOList[1].ingredientName); //this prints the second element in the current recipe
                


                waitingRecipeSOList.Add(waitingRecipeSO);

            }
        }
    }


  
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             