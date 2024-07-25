using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPosition : MonoBehaviour
{
    public GameObject wrapper;
    public GameObject fillingBall;
    public GameObject waterRing;
    public Vector3 targetPosition;
    public float tolerance = 0.1f;

    public GameObject[] hideIngredients;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAtPosition(waterRing, targetPosition, tolerance))
        {

            foreach (GameObject obj in hideIngredients)
            {
                obj.SetActive(false);
            }
        }
    }

    bool isAtPosition(GameObject obj, Vector3 targetPos, float tolerance)
    {
        float distance = Vector3.Distance(obj.transform.position, targetPos);

        return distance <= tolerance;
    }



}
