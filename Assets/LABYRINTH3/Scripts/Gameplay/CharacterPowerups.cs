using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace Labyrinth3.Gameplay{
    public class CharacterPowerups : MonoBehaviour
    {
        public CharacterMovement characterMovement;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("speed"))
            {
                characterMovement.speed = 8.5f;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("hourglass"))
            {
                // count_d.timeStart += 60f;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.CompareTag("jump"))
            {
                characterMovement.jumpHeight += 10f;
                Destroy(collision.gameObject);
            }
        }
    }
}