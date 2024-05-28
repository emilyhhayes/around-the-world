using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientManager : MonoBehaviour
{
    public GameObject[] hideIngredients;
    [SerializeField] private recipeListSO recipeListSO;
    private List<recipesSO> waitingRecipeSOList;

    private void Awake()
    {
        foreach (GameObject obj in hideIngredients)
        {
            obj.SetActive(false);
        }
    }



}
