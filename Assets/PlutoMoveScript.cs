using Unity.VisualScripting;
using UnityEditor.IMGUI.Controls;
using UnityEditor.Rendering;
using UnityEngine;
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
            myRigidbody.linearVelocity = Vector2.right * goRightPower;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            myRigidbody.linearVelocity = Vector2.left * goLeftPower;
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && playerCollider.IsTouchingLayers())
        {
            myRigidbody.linearVelocity = Vector2.up * goUpPower;
        }

        if (transform.position.y <= -10)
        {
            transform.position = startPosision;
        }

        if (playerCollider.IsTouching(endPlatform))
        {
            SceneManager.LoadScene("2");
        }
    }
}
