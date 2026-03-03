using UnityEngine;
using System.Collections; // Required for Coroutines

public class BallRelease : MonoBehaviour
{
    [Header("Settings")]
    public float targetLowerY = 3.25f;
    public float targetRaiseY = 3.8f;
    public float transitionSpeed = 1f;
    public float lowerDelay = 0.5f;

    private bool shouldLower = false;
    private bool shouldRaise = false;
    private Vector3 targetPositionLower;
    private Vector3 targetPositionRaise;

    void Start() {
        UpdateTargetPositions();
    }

    void UpdateTargetPositions() {
        targetPositionLower = new Vector3(transform.position.x, targetLowerY, transform.position.z);
        targetPositionRaise = new Vector3(transform.position.x, targetRaiseY, transform.position.z);
    }

    void Update() {
        if (shouldLower) {
            transform.position = Vector3.Lerp(transform.position, targetPositionLower, Time.deltaTime * transitionSpeed);
            if (Mathf.Abs(transform.position.y - targetLowerY) < 0.001f) {
                transform.position = targetPositionLower;
                shouldLower = false;
            }
        }

        if (shouldRaise) {
            transform.position = Vector3.Lerp(transform.position, targetPositionRaise, Time.deltaTime * transitionSpeed);
            if (Mathf.Abs(transform.position.y - targetRaiseY) < 0.001f) {
                transform.position = targetPositionRaise;
                shouldRaise = false;
            }
        }
    }

    public void StartLowering()
    {
        StopAllCoroutines(); 
        StartCoroutine(LowerAfterDelay());
    }

    private IEnumerator LowerAfterDelay() {
        shouldRaise = false;
        yield return new WaitForSeconds(lowerDelay);
        UpdateTargetPositions();
        shouldLower = true;
    }

    public void StartRaising() {
        StopAllCoroutines(); 
        shouldLower = false;
        shouldRaise = true;
    }
}