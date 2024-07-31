﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ingredientManager : MonoBehaviour
{
    public GameObject[] hideIngredients;

    [SerializeField] private recipeListSO recipeListSO;
    [SerializeField] public ingredientSO minceIngredientSO;
    [SerializeField] private recipesSO assembleCheck;

    private List<recipesSO> waitingRecipeSOList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4f;
    private int waitingRecipesMax = 1;
    public List<string> droppedIngredients = new List<string>();
    
    public GameObject fillingBall; 
    public GameObject mince;
    public GameObject wrapper;
    public GameObject assembleArea;
    public GameObject waterRing;
    public GameObject dumpling;


    
    public dragDrop dragDrop; 
    public List<GameObject> droppedObjects = new List<GameObject>();
    public List<GameObject> dumplingFilling; 

    public Vector3 newPosition;
    public Vector3 targetPosition;
    public float tolerance = 0.1f;
    public float movement = 2.5f;

    public string stage = "prep";


    void Start()
    {
        
    }



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






    public void addIngredients(string ingredientName, GameObject ingredientObject)
    {
        droppedIngredients.Add(ingredientName);
        droppedObjects.Add(ingredientObject);

        foreach (string droppedIngredientName in droppedIngredients)
        {
            Debug.Log("in here is" + droppedIngredientName);
        }

    }


    public void checkPrep()
    {
        foreach (recipesSO recipe in waitingRecipeSOList)
        {
            Debug.Log("checkingrecipe" + recipe.recipeName);


            bool allMatch = true;

            for (int i = 0; i < recipe.ingredientSOList.Count; i++)
            {
                string recipeIngredient = recipe.ingredientSOList[i].ingredientName;

                if (!droppedIngredients.Contains(recipeIngredient))
                {
                    allMatch = false; break;

                }
            }

            if (allMatch)
            {
                Debug.Log("All dropped ingredients match the recipe: " + recipe.recipeName);


                fillingBall.SetActive(true);

                foreach (GameObject obj in droppedObjects)
                {
                    Destroy(obj);
                }


                droppedIngredients.Clear();
                droppedObjects.Clear();

               
                StartCoroutine(MoveToPosition(fillingBall, newPosition, movement));
                StartCoroutine(MoveToPosition(wrapper, newPosition, movement));
                stage = "assemble";
            }

            else
            {
                Debug.Log("Some dropped ingredients do not match the recipe: " + recipe.recipeName);


            }
        }
    }


    public void checkAssembly()
    {

        wrapper.SetActive(false);
        waterRing.SetActive(false);
        fillingBall.SetActive(false);
        dumpling.SetActive(true);

 





    }


    public void CheckIngredients()
    {
        if (stage == "prep")
        {
            checkPrep();
        }
        else if (stage == "assemble")
        {
            Debug.Log("Im going to check the assemply");
            checkAssembly();
        }
    }

 IEnumerator MoveToPosition(GameObject obj, Vector3 target, float movement)
    {
        Vector3 start = obj.transform.position;
        float elapsedTime = 0;

        while (elapsedTime < movement)
        {
            elapsedTime += Time.deltaTime;
            obj.transform.position = Vector3.Lerp(start, target, elapsedTime / movement);
            yield return null;
        }

        obj.transform.position = target;
    }

    


}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             