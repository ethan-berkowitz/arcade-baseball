using UnityEngine;

public class Ball : MonoBehaviour
{
    public Status status;
	public LightToggle light_toggle;

	void Start()
	{
		status = FindObjectOfType<Status>();
		light_toggle = FindObjectOfType<LightToggle>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
            status.outcome = "strike";
			//light_toggle.light_name = "strike";
			Destroy(gameObject);
		}
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SingleLeft"))
		{
            status.outcome = "single";
			light_toggle.light_name = "singleleft";
		}
        else if (collision.gameObject.CompareTag("SingleRight"))
		{
            status.outcome = "single";
			light_toggle.light_name = "singleright";
		}
        else if (collision.gameObject.CompareTag("DoubleLeft"))
		{
            status.outcome = "double";
			light_toggle.light_name = "doubleleft";
		}
        else if (collision.gameObject.CompareTag("DoubleRight"))
		{
            status.outcome = "double";
			light_toggle.light_name = "doubleright";
		} 
        else if (collision.gameObject.CompareTag("Triple"))
		{
            status.outcome = "triple";
			light_toggle.light_name = "triple";
		}
        else if (collision.gameObject.CompareTag("HomeRun"))
		{
            status.outcome = "homerun";
			//light_toggle.light_name = "homerun";
		}
        else if (collision.gameObject.CompareTag("OutLeft"))
		{
            status.outcome = "out";
			light_toggle.light_name = "outleft";
		}
        else if (collision.gameObject.CompareTag("OutRight"))
		{
            status.outcome = "out";
			light_toggle.light_name = "outright";
		}
        else if (collision.gameObject.CompareTag("Strike"))
		{
            status.outcome = "strike";
			//light_toggle.light_name = "strike";
		}
		else
			return;
		Destroy(gameObject);
    }
}
