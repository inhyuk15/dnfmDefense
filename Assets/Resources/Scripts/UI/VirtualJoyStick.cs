using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Vector3 Direction { get; private set; }

    [SerializeField]
    private RectTransform controller;

    [SerializeField]
    private RectTransform background;

    [SerializeField, Range(10f, 150f)]
    private float controllerRange;

    public void ProcessDrag(PointerEventData e)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background,
            e.position,
            e.pressEventCamera,
            out Vector2 localPoint
        );
        var inputDir = localPoint - background.anchoredPosition;
        var clampedDir =
            inputDir.magnitude < controllerRange ? inputDir : inputDir.normalized * controllerRange;
        controller.anchoredPosition = clampedDir;
        Direction = new Vector3(clampedDir.normalized.x, 0f, clampedDir.normalized.y);
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
