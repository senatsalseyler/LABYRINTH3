using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;

namespace LABYRINTH3.UI
{
    public class DynamiJoystick : OnScreenControl, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] protected RectTransform background = null;
        [SerializeField] private RectTransform handle = null;
        private RectTransform rect = null;

        public float movementRange
        {
            get => m_MovementRange;
            set => m_MovementRange = value;
        }

        [SerializeField]
        private float m_MovementRange = 50;

        [InputControl(layout = "Vector2")]
        [SerializeField]
        private string m_ControlPath;

        private Camera cam;

        private Vector2 m_PointerDownPos;

        protected override string controlPathInternal
        {
            get => m_ControlPath;
            set => m_ControlPath = value;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException(nameof(eventData));

            background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
            background.gameObject.SetActive(true);
        }

        protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
        {
            Vector2 localPoint = Vector2.zero;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPosition, cam, out localPoint))
            {
                Vector2 pivotOffset = rect.pivot * rect.sizeDelta;
                return localPoint - (background.anchorMax * rect.sizeDelta) + pivotOffset;
            }
            return Vector2.zero;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData == null)
                throw new System.ArgumentNullException(nameof(eventData));

            RectTransformUtility.ScreenPointToLocalPointInRectangle(handle, eventData.position, eventData.pressEventCamera, out var position);
            var delta = position - m_PointerDownPos;

            delta = Vector2.ClampMagnitude(delta, movementRange);
            handle.anchoredPosition = (Vector3)delta;

            var newPos = new Vector2(delta.x / movementRange, delta.y / movementRange);
            SendValueToControl(newPos);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            SendValueToControl(Vector2.zero);
            background.gameObject.SetActive(false);
        }

        private void Start()
        {
            rect = GetComponent<RectTransform>();
            background.gameObject.SetActive(false);
        }



    }
}