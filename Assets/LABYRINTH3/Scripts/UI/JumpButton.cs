using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Labyrinth3.UI
{
    public class JumpButton : MonoBehaviour, ISelectHandler, IDeselectHandler

    {
        private bool isJumpButtonPressed = false;

        public void OnSelect(BaseEventData eventData)
        {
            isJumpButtonPressed = true;
        }

        public void OnDeselect(BaseEventData eventData)
        {
            isJumpButtonPressed = false;
        }
    }
}