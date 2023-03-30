using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomButton : Button
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        // Disable the pressed state
        interactable = false;

        // Call the base method to handle the highlight state
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        // Enable the button again
        interactable = true;

        // Call the base method to handle the highlight state
        base.OnPointerUp(eventData);
    }
}
