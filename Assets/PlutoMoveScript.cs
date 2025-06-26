using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlutoMoveScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public PolygonCollider2D playerCollider;
    public float goRightPower;
    public float goLeftPower;
    public float goUpPower;
    private Vector3 startPosision;
    public Collider2D endPlatform;
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
        startPosision = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            myRigidbody.linearVelocity += Vector2.right * goRightPower;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myRigidbody.linearVelocity += Vector2.left * goLeftPower;
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && playerCollider.IsTouchingLayers())
        {
            myRigidbody.linearVelocity += Vector2.up * goUpPower;
        }

        if (transform.position.y <= -10)
        {
            transform.position = startPosision;
        }

        if (playerCollider.IsTouching(endPlatform))
        {
            var currentScene = SceneManager.GetActiveScene().name;
            var index = Array.IndexOf(levels, currentScene);
            SceneManager.LoadScene(levels[index + 1]);
        }

        if (myRigidbody.linearVelocity.x > 3)
        {
            myRigidbody.linearVelocity = new Vector3(3, myRigidbody.linearVelocity.y);
        }

        if (myRigidbody.linearVelocity.x < -3)
        {
            myRigidbody.linearVelocity = new Vector3(-3, myRigidbody.linearVelocity.y);
        }
    }
}
