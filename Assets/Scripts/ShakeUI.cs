using UnityEngine;

public class ShakeUI : MonoBehaviour
{
    public float shakeDuration = 0.5f; // The duration of the shake in seconds
    public float shakeAmount = 1f; // The amount of shake in units
    public float decreaseFactor = 1f; // The rate at which the shake decreases

    private Vector3 originalPosition; // The original position of the game object
    private float shakeTimeRemaining = 0f; // The remaining time of the shake
    private Vector3 shakeOffset; // The offset caused by the shake

    private void Start()
    {
        originalPosition = transform.position; // Set the original position to the game object's position
        InvokeRepeating("StartShake", 1f, 1f);
    }

    private void Update()
    {
        if (shakeTimeRemaining > 0f)
        {
            shakeOffset = Random.insideUnitSphere * shakeAmount; // Calculate a random offset within the shake amount
            transform.position = originalPosition + shakeOffset; // Apply the offset to the game object's position
            shakeTimeRemaining -= Time.deltaTime * decreaseFactor; // Decrease the remaining time of the shake
        }
        else
        {
            shakeTimeRemaining = 0f; // Reset the remaining time of the shake
            transform.position = originalPosition; // Reset the game object's position to the original position
        }
    }

    public void StartShake()
    {
        SoundManager.Instance.PlaySFX(SoundManager.Instance.Notification);

        shakeTimeRemaining = shakeDuration; // Set the remaining time of the shake to the shake duration
    }
}

