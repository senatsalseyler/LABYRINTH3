using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class chr_movement2: MonoBehaviour
{
    public GameObject player;
    public CharacterController controller;
    public countDown count_d;
    
    public float speed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    Vector3 velocity;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "speed")
        {
            speed = 8.5f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "hourglass")
        {
            count_d.timeStart +=60f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "jump")
        {
            jumpHeight += 10f;
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if(Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
