using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winningButton : MonoBehaviour
{
    public GameObject button;


    public void OnButtonPress()
    {
        button.SetActive(true);
    }
}
