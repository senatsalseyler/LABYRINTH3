using Labyrinth3.Game;
using UnityEngine;
using Labyrinth3.Game;
namespace Labyrinth3.Gameplay
{
    public class TimePowerupPickup : Pickup
    {
        public float timeAddition = 10f;
        private void OnTriggerEnter(Collider collision)
        {
            TimePowerupPickupEvent evt = Events.TimePowerupPickupEvent;
            evt.pickup = gameObject;
            evt.value = timeAddition;
            EventManager.Broadcast(evt);
            Destroy(gameObject);
        }
    }
}