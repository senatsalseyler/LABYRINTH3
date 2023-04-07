using System;
using LABYRINTH3.Game;
using UnityEngine;
using UnityEngine.InputSystem;
using Cursor = UnityEngine.Cursor;

namespace Labyrinth3.Gameplay
{
    public class CharacterMovement : MonoBehaviour
    {
        public CharacterController controller;

        public float speed;
        public float gravity = -9.81f;
        public float jumpHeight = 3f;

        public float mouseSensitivity = 2f;
        public Transform camera;
        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;
        Vector3 velocity;
        public PlayerInput playerInput;
        private InputAction m_Move;
        private InputAction m_Look;

        private Vector3 move;
        private bool isGrounded = false;
        private float xRotation;
        private float yRotation;

        public AudioSource footsteps;
        private void Awake()
        {
            m_Move = playerInput.currentActionMap.FindAction("Move");
            m_Look = playerInput.currentActionMap.FindAction("Look");
        }

        void Start()
        {
            xRotation = camera.transform.rotation.eulerAngles.x;
            yRotation = camera.transform.rotation.eulerAngles.y;
        }
        public void OnJump(InputAction.CallbackContext movementValue)
        {
            bool isJumpPressed = movementValue.ReadValue<float>() > 0;
            if (isJumpPressed && isGrounded)
            {
                move.y = jumpHeight;
                footsteps.enabled = true;
            }
            else
            {
                footsteps.enabled = false;
            }


        }

        private void FixedUpdate()
        {
            Vector2 movementVector = m_Move.ReadValue<Vector2>();
            move.x = movementVector.x;
            move.z = movementVector.y;
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            move.y += gravity * Time.deltaTime;
            Vector2 mouseVector = m_Look.ReadValue<Vector2>();
            float mouseX = mouseVector.x * Time.deltaTime * mouseSensitivity;
            float mouseY = mouseVector.y * Time.deltaTime * mouseSensitivity;
            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            camera.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            transform.rotation = Quaternion.Euler(0, yRotation, 0);

            controller.Move(transform.TransformDirection(move) * speed * Time.deltaTime);
        }
    }
}