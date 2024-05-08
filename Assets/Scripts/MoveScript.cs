using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveScript : MonoBehaviour
{
    [SerializeField]
    private CharacterController playerController;

    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private float gravity = -9.81f;

    [SerializeField]
    private Transform groundCheck;
    private float groundDistance = 0.1f;
    [SerializeField]
    private LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    [SerializeField] private GameObject uvLight;
    [SerializeField] private GameObject videoCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwapItem();
        }

        //creates a sphere in which it will check if it is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //checking if the player is on the ground and if they have a negative vertical velocity
        //it will then set the velocity to -2 so that it doesnt continue to increase forever
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //the following will get the movement keys and cause the character controller for the player to be moved accordingly.X
        float x = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");
        Vector3 movePlayer = transform.right * x + transform.forward * Z;
        playerController.Move(movePlayer * moveSpeed * Time.deltaTime);

        //applies the vertical velocity to the player whilst ensuring gravity is ever present
        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void SwapItem()
    {
        uvLight.gameObject.SetActive(!uvLight.activeSelf);
        videoCamera.gameObject.SetActive(!videoCamera.activeSelf);
    }

}
