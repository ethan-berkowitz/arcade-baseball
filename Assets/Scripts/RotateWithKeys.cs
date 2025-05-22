using UnityEngine;

public class RotateWithKeys : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Rotate left
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            // Rotate right
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            // Rotate right
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }
}
