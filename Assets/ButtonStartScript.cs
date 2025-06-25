using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ButtonStartScript : MonoBehaviour
{
    public readonly String[] levels = {
        "Title",
        "1",
        "2",
        "3",
        "4"
    };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene(levels[1]);
    }
}
