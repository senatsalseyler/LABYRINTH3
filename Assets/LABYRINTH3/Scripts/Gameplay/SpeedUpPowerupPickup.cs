using UnityEngine;
using Labyrinth3.Game;

namespace Labyrinth3.Gameplay
{
    public class SpeedUpPowerupPickup : Pickup
    {
        public float speedUpValue = 8.5f;

        private void OnTriggerEnter(Collider collision)
        {
            CharacterMovement player = collision.GetComponent<CharacterMovement>();
            player.speed = speedUpValue;
            SpeedUpPowerupPickupEvent evt = Events.SpeedUpPowerupPickupEvent;
            evt.pickup = gameObject;
            evt.value = speedUpValue;
            EventManager.Broadcast(evt);
            Destroy(gameObject);
        }
    }
}