using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 Direction { get; private set; }

    [SerializeField]
    private RectTransform controller;

    [SerializeField]
    private RectTransform background;

    private float controllerRange;

    void Start()
    {
        controllerRange = background.sizeDelta.x / 2;
    }

    public void ProcessDrag(PointerEventData e)
    {
        Vector2 pointerPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background,
            e.position,
            e.pressEventCamera,
            out pointerPos
        );

        Vector2 movedPos = pointerPos - background.anchoredPosition;
        movedPos = Vector2.ClampMagnitude(movedPos, controllerRange);
        controller.anchoredPosition = movedPos;
        Direction = new Vector3(movedPos.x / controllerRange, 0, movedPos.y / controllerRange);
    }

    public void OnBeginDrag(PointerEventData e)
    {
        ProcessDrag(e);
    }

    public void OnDrag(PointerEventData e)
    {
        ProcessDrag(e);
    }

    public void OnEndDrag(PointerEventData e)
    {
        controller.anchoredPosition = Vector2.zero;
        Direction = Vector3.zero;
    }
}
