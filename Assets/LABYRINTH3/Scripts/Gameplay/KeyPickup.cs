using UnityEngine;
using Labyrinth3.Game;

namespace Labyrinth3.Gameplay
{
    public class KeyPickup : Pickup
    {
        public AudioSource achievement;
        private void OnTriggerEnter(Collider collision)
        {
            achievement.enabled = true;
            Destroy(gameObject);
            KeyPickupEvent evt = Events.KeyPickupEvent;
            EventManager.Broadcast(evt);
        }
    }
}