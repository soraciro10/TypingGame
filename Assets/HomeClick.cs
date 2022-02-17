using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeClick : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void HomeButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
