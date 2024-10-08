using UnityEngine;

public class UIMoveLerp : MonoBehaviour
{
    public RectTransform uiElement;  // The UI element to move
    public Vector3 pointA;  // Starting point
    public Vector3 pointB;  // Target point
    public float duration = 1f;  // Time to complete the movement

    private float _elapsedTime = 0f;

    void Start()
    {

    }

    void Update()
    {
        // Move the UI element from point A to point B over time
        if (_elapsedTime < duration)
        {
            _elapsedTime += Time.deltaTime;
            float t = _elapsedTime / duration;

            // Lerp from pointA to pointB based on time (t)
            uiElement.anchoredPosition = Vector3.Lerp(pointA, pointB, t);
        }
    }
}
