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
    
    public GameObject fillingBall; 
    public GameObject mince;
    public GameObject wrapper;
 
    
    public dragDrop dragDrop; 
    public List<GameObject> droppedObjects = new List<GameObject>();

    public Vector3 newPosition;
    public float movement = 2.5f;
 

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

    public void CheckIngredients()
    {
        foreach (recipesSO recipe in waitingRecipeSOList)
        {
            Debug.Log("checkingrecipe" +  recipe.recipeName);

            
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

                // Clear the lists after hiding the objects
                droppedIngredients.Clear();
                droppedObjects.Clear();
            //wrapper.transform.position = new Vector3(2.44f, 2.03f, -0.04822773f); // Example new position
          
          StartCoroutine(MoveToPosition(fillingBall, newPosition, movement));
           StartCoroutine(MoveToPosition(wrapper, newPosition, movement)); 

            }

            else
            {
                Debug.Log("Some dropped ingredients do not match the recipe: " + recipe.recipeName);


            }
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             