using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public GameObject button;
    public GameObject correctText;
    public GameObject tickButton;


    
    public dragDrop dragDrop; 
    public List<GameObject> droppedObjects = new List<GameObject>();
    public List<GameObject> dumplingFilling; 

    public Vector3 newPosition;
    public Vector3 targetPosition;
    public float tolerance = 0.1f;
    public float movement = 2.5f;

    public string stage = "prep";
    public static ingredientManager instance;


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

        if (instance == null)
        {
            instance = this;
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
        if (droppedIngredients.Count == 2)
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

                    correctText.SetActive(true);

                
                    StartCoroutine(MoveToPosition(fillingBall, newPosition, movement));
                    StartCoroutine(MoveToPosition(wrapper, newPosition, movement));
                    stage = "assemble";
                }

                else
                {
                    button.SetActive(true);
                    Debug.Log("Some dropped ingredients do not match the recipe: " + recipe.recipeName);
                    

                }

            }    
        }
    }


    public void checkAssembly()
    {

        wrapper.SetActive(false);
        waterRing.SetActive(false);
        fillingBall.SetActive(false);
        dumpling.SetActive(true);
        tickButton.SetActive(true);

        Destroy(assembleArea);


    }


    public void CheckIngredients()
    {
        if (stage == "prep")
        {
            checkPrep();
        }
        else if (stage == "assemble")
        {
            checkAssembly();
        }

    }


    public void setStage(string cook)
    {
        stage = cook;
    }

    public string GetStage()
    {
        return stage;
     
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             