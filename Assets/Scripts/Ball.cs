using UnityEngine;

public class Ball : MonoBehaviour
{
    public Status status;
	public LightToggle light_toggle;

	void Start() {
		status = FindObjectOfType<Status>();
		light_toggle = FindObjectOfType<LightToggle>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
            status.outcome = "strike";
			Destroy(gameObject);
		}
	}

void OnCollisionEnter(Collision collision) 
{
    string tag = collision.gameObject.tag;

    switch (tag)
    {
        case "SingleLeft":
            status.outcome = "single";
            light_toggle.light_name = "singleleft";
            break;
        case "SingleRight":
            status.outcome = "single";
            light_toggle.light_name = "singleright";
            break;
        case "DoubleLeft":
            status.outcome = "double";
            light_toggle.light_name = "doubleleft";
            break;
        case "DoubleRight":
            status.outcome = "double";
            light_toggle.light_name = "doubleright";
            break;
        case "Triple":
            status.outcome = "triple";
            light_toggle.light_name = "triple";
            break;
        case "HomeRun":
            status.outcome = "homerun";
            break;
        case "OutLeft":
            status.outcome = "out";
            light_toggle.light_name = "outleft";
            break;
        case "OutRight":
            status.outcome = "out";
            light_toggle.light_name = "outright";
            break;
        case "Strike":
            status.outcome = "strike";
            break;
        default:
            return;
    }
    Destroy(gameObject);
}
}
