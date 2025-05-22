using UnityEngine;

public class Status : MonoBehaviour
{
    public int swings = 0;  // Public: visible in the Inspector
	public bool hit_single = false;
	public bool hit_double = false;
	public bool hit_triple = false;
	public bool hit_homerun = false;
	public bool hit_out = false;
	

    void Start()
    {

    }

    void Update()
    {
        // Example: Increase score when pressing space
        if (Input.GetKeyDown(KeyCode.Space))
            swings++;
    }
}
