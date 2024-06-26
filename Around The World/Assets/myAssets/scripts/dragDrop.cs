using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class dragDrop : MonoBehaviour
{
    private bool _dragging, _placed;
    private Vector2 _offset, _originalPosition;
    public GameObject mince;
    private bool mouseHeldDown = false;
    public GameObject crackedEggPrefab;
    public ingredientManager ingredientManager;



    void Awake() {
        _originalPosition = transform.position;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!_dragging) return;
        if (_placed) return; 

        var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePosition - _offset;
    }

    void OnMouseDown() {

        mouseHeldDown = true;
        
        if (crackedEggPrefab != null)
        {
            crackedEggPrefab.SetActive(true);
            
        }
          
        
        
         _dragging = true;

        _offset = GetMousePos() - (Vector2)transform.position;



    }

    void OnMouseUp() {
        ingredientManager ingredientManager = FindObjectOfType<ingredientManager>();
        if (Vector2.Distance(transform.position, mince.transform.position) < 2)
        {
            transform.position = mince.transform.position;
            _placed = true;
            string ingredientName = crackedEggPrefab.GetComponent<ingredientObject>().ingredientData.ingredientName;
            Debug.Log(ingredientName);
            ingredientManager.addIngredients(ingredientName);


            CompareIngredients();

        }
        else
        {
            transform.position = _originalPosition;
            _dragging = false;  
        }



    }

   private void CompareIngredients()
    {
        ingredientManager ingredientManager = FindObjectOfType<ingredientManager>();
        if (ingredientManager != null)
        {
            ingredientManager.CheckIngredients();
        }

    }

    Vector2 GetMousePos(){

        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }



}


