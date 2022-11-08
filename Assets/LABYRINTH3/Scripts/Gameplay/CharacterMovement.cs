using System;
using LABYRINTH3.Game;
using UnityEngine;
using UnityEngine.InputSystem;
using Cursor = UnityEngine.Cursor;

namespace Labyrinth3.Gameplay
{
    public class CharacterMovement : MonoBehaviour, PlayerControls.IPlayerActions
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
        private PlayerControls playerControls;

        private Vector3 move;
        private bool isGrounded = false;
        private float xRotation;
        private float yRotation;

        void Start()
        {
            xRotation = camera.transform.rotation.eulerAngles.x;
            yRotation = camera.transform.rotation.eulerAngles.y;
        }

        private void Awake()
        {
            playerControls = new PlayerControls();
            playerControls.Player.SetCallbacks(this);
        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        public void OnJump(InputAction.CallbackContext movementValue)
        {
            bool isJumpPressed = movementValue.ReadValue<float>() > 0;
            if (isJumpPressed && isGrounded)
            {
                move.y = jumpHeight;
            }
        }

        public void OnLook(InputAction.CallbackContext movementValue)
        {
        }

        public void OnMove(InputAction.CallbackContext context)
        {
        }

        private void FixedUpdate()
        {
            Debug.Log("FixedUpdate");
            Vector2 movementVector = playerControls.Player.Move.ReadValue<Vector2>();
            move.x = movementVector.x;
            move.z = movementVector.y;
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            move.y += gravity * Time.deltaTime;

            Vector2 mouseVector = playerControls.Player.Look.ReadValue<Vector2>();
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