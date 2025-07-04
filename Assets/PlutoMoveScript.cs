#nullable enable

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
    public Collider2D? endPlatform;
    public Collider2D? secretPlatform;
    public Collider2D? returnPlatform;
    private GameLevels levels = new GameLevels();

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

        if (endPlatform != null && playerCollider.IsTouching(endPlatform))
        {
            Debug.Log("touch end");
            levels.Next();
        }

        if (secretPlatform != null && playerCollider.IsTouching(secretPlatform))
        {
            Debug.Log("touch secret");
            SceneManager.LoadScene("3SecretLevel");
        }

        if (returnPlatform != null && playerCollider.IsTouching(returnPlatform))
        {
            Debug.Log("touch return");
            SceneManager.LoadScene("4");
        }

        if (myRigidbody.linearVelocity.x > 3)
        {
            Debug.Log("too fast r");
            myRigidbody.linearVelocity = new Vector3(3, myRigidbody.linearVelocity.y);
        }

        if (myRigidbody.linearVelocity.x < -3)
        {
            Debug.Log("too fast l");
            myRigidbody.linearVelocity = new Vector3(-3, myRigidbody.linearVelocity.y);
        }
    }
}
