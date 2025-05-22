using UnityEngine;

public class DestroyIfBelow : MonoBehaviour
{
    public float destroyYThreshold = -10f;

    void Update()
    {
        if (transform.position.y < destroyYThreshold)
        {
            Destroy(gameObject);
        }
    }
}
