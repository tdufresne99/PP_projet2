using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
    public float scaleFactor = 1.2f; // the amount to scale the UI element by on hover
    public float duration = 0.2f; // the duration of the scaling animation
    private Vector3 defaultScale; // the default scale of the UI element
    private bool isHovering = false; // whether the mouse is currently hovering over the UI element
    
    // Get the default scale of the UI element and set the parent's anchors if a RectTransform component is present
    private void Awake()
    {
        Debug.Log("hoverScale");
        defaultScale = transform.localScale;
        
        RectTransform parentRectTransform = transform.parent.GetComponent<RectTransform>();
        if (parentRectTransform != null)
        {
            parentRectTransform.anchorMin = new Vector2(0f, 0f);
            parentRectTransform.anchorMax = new Vector2(1f, 1f);
        }
    }
    
    // Scale up the UI element on mouse hover
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
        StartCoroutine(ScaleCoroutine(defaultScale * scaleFactor, duration));
    }
    
    // Scale back down the UI element when the mouse stops hovering over it
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
        StartCoroutine(ScaleCoroutine(defaultScale, duration));
    }
    
    // Coroutine to smoothly scale the UI element over a period of time
    private IEnumerator ScaleCoroutine(Vector3 targetScale, float duration)
    {
        float timer = 0f;
        Vector3 startScale = transform.localScale;
        
        while (timer < duration)
        {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, targetScale, timer / duration);
            yield return null;
        }
        
        transform.localScale = targetScale;
    }
    
    // If the UI element is still being scaled up/down when the scene changes, stop the coroutine to prevent errors
    private void OnDestroy()
    {
        if (isHovering)
        {
            StopAllCoroutines();
            transform.localScale = defaultScale;
        }
    }
}
