using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newScript : MonoBehaviour
{
    private bool _dragging;
    private Vector2 _offset, _originalPosition;


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

        var mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePosition - _offset;
    }

    void OnMouseDown() {

        _dragging = true;

        _offset = GetMousePos() - (Vector2)transform.position;

    }

    void OnMouseUp() {
        transform.position = _originalPosition;
        _dragging = false; 
    }

    Vector2 GetMousePos(){

        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }



}


