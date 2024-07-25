using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPosition : MonoBehaviour
{

    private void OnCollisionEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "wrapper")
        {
            Debug.Log("yay");
        }
        
    }



}
