using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragDrop : MonoBehaviour
{
    private bool _dragging, _placed;
    private Vector2 _offset, _originalPosition;
    public GameObject mince;
    private bool mouseHeldDown = false;
    public GameObject crackedEggPrefab;
    public GameObject crackedEgg;


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
        
        if (crackedEgg != null)
        {
            crackedEgg.SetActive(true);
        }
          
        
        
         _dragging = true;

        _offset = GetMousePos() - (Vector2)transform.position;

    }

    void OnMouseUp() {
        if (Vector2.Distance(transform.position, mince.transform.position) < 2)
        {
            transform.position = mince.transform.position;
            _placed = true;
        }
        else
        {
            transform.position = _originalPosition;
            _dragging = false;  
        }
    }

    Vector2 GetMousePos(){

        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }



}


