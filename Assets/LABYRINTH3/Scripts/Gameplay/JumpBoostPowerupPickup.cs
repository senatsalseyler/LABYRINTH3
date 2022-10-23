using UnityEngine;
using Labyrinth3.Game;

namespace Labyrinth3.Gameplay
{
    public class JumpBoostPickup : Pickup
    {
        public float jumpBoostValue = 10f;
        private void OnTriggerEnter(Collider collision)
        {
            CharacterMovement player = collision.GetComponent<CharacterMovement>();
            player.jumpHeight += 10f;
            Destroy(collision.gameObject);
            JumpBoostPowerupPickupEvent evt = Events.JumpBoostPowerupPickupEvent;
            evt.pickup = gameObject;
            evt.value = jumpBoostValue;
            EventManager.Broadcast(evt);
        }
    }
}