using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientManager : MonoBehaviour
{
    public GameObject[] hideIngredients;

    private void Awake()
    {
        foreach (GameObject obj in hideIngredients)
        {
            obj.SetActive(false);
        }
    }



}
