using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.ComponentModel;
using UnityEngine.SceneManagement;

public class NewPlayer : MonoBehaviour
{
    private Vector2 moveVal;
    public float moveSpeed = 1.0f;

    public float jumpForce = 2.0f;
    private Vector3 jump;
    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        isGrounded = true;
    }

    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }
    public void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, moveVal.x) * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (this.CompareTag("Player") && other.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}