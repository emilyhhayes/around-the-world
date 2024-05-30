using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredientObject : MonoBehaviour
{
    [SerializeField] private ingredientSO ingredientSO;

    public ingredientSO GetingredientSO()
    {
        return ingredientSO;
    }
}
