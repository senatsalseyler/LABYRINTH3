using UnityEngine;

namespace Labyrinth3.Game
{
    public static class Events
    {
        public static TriedToEndWithoutCollectingKeysEvent triedToEndWithoutCollectingKeysEvent =
            new TriedToEndWithoutCollectingKeysEvent();

        public static KeyPickupEvent KeyPickupEvent = new KeyPickupEvent();
        public static SpeedUpPowerupPickupEvent SpeedUpPowerupPickupEvent = new SpeedUpPowerupPickupEvent();
        public static TimePowerupPickupEvent TimePowerupPickupEvent = new TimePowerupPickupEvent();
        public static JumpBoostPowerupPickupEvent JumpBoostPowerupPickupEvent = new JumpBoostPowerupPickupEvent();
        public static EndLevelEvent EndLevelEvent = new EndLevelEvent();
        public static LoseLevelEvent LoseLevelEvent = new LoseLevelEvent();
    }

    public class GameEvent
    {
    };

    public class PickUpBase : GameEvent
    {
        public GameObject pickup;
    }

    public class TriedToEndWithoutCollectingKeysEvent : GameEvent
    {
    };

    public class KeyPickupEvent : GameEvent
    {
        public GameObject key;
        public float collectedKeys;
        public float remainingKeys;
    };

    public class SpeedUpPowerupPickupEvent : PickUpBase
    {
        public float value;
    };

    public class TimePowerupPickupEvent : PickUpBase
    {
        public float value;
    };

    public class JumpBoostPowerupPickupEvent : PickUpBase
    {
        public float value;
    };

    public class LoseLevelEvent : GameEvent
    {
    };
    public class EndLevelEvent : GameEvent
    {
    };
}