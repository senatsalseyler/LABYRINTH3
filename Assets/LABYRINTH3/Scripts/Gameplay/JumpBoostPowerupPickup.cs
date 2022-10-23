using UnityEngine;
using Labyrinth3.Game;

namespace Labyrinth3.Gameplay
{
    public class JumpBoostPowerupPickup : Pickup
    {
        public float jumpBoostValue = 10f;
        private void OnTriggerEnter(Collider collision)
        {
            CharacterMovement player = collision.GetComponent<CharacterMovement>();
            player.jumpHeight += jumpBoostValue;
            JumpBoostPowerupPickupEvent evt = Events.JumpBoostPowerupPickupEvent;
            evt.pickup = gameObject;
            evt.value = jumpBoostValue;
            EventManager.Broadcast(evt);
            Destroy(gameObject);
        }
    }
}