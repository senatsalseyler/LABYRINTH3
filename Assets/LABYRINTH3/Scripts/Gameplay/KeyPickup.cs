using UnityEngine;
using Labyrinth3.Game;

namespace Labyrinth3.Gameplay
{
    public class KeyPickup : Pickup
    {
        private void OnTriggerEnter(Collider collision)
        {
            Destroy(gameObject);
            KeyPickupEvent evt = Events.KeyPickupEvent;
            EventManager.Broadcast(evt);
        }
    }
}