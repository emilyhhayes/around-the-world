using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOne : MonoBehaviour
{
    public Vector3 newPosition;
    public float movement = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToPosition(newPosition, movement));  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveToPosition(Vector3 target, float movement)
    {
        Vector3 start = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < movement)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(start, target, elapsedTime / movement);
            yield return null;
        }

        transform.position = target;
    }
}
