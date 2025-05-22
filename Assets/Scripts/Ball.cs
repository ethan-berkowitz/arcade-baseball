using UnityEngine;

public class Ball : MonoBehaviour
{
    public Status status;  // Reference to another script where the bool lives


	void Start()
	{
		status = FindObjectOfType<Status>();
	}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Single")) 
            status.hit_single = true;
        else if (collision.gameObject.CompareTag("Double")) 
            status.hit_double = true;
        else if (collision.gameObject.CompareTag("Triple")) 
            status.hit_triple = true;
        else if (collision.gameObject.CompareTag("Out")) 
            status.hit_out = true;
		else
			return;
		Destroy(gameObject);
    }
}
