using UnityEngine;
using System.Collections;

public class LightToggle : MonoBehaviour
{
    public Light hitLightSingleLeft;
	public Light hitLightSingleRight;
	public Light hitLightOutLeft;
	public Light hitLightOutRight;
	public Light hitLightDoubleLeft;
	public Light hitLightDoubleRight;
	public Light hitLightTriple;
	public string light_name = "";

    void Update()
    {
		if (light_name != "")
			turn_off_all();
		if (light_name == "singleleft")
			hitLightSingleLeft.enabled = true;
		else if (light_name == "singleright")
			hitLightSingleRight.enabled = true;
		else if (light_name == "doubleleft")
			hitLightDoubleLeft.enabled = true;
		else if (light_name == "doubleright")
			hitLightDoubleRight.enabled = true;
		else if (light_name == "triple")
			hitLightTriple.enabled = true;
		else if (light_name == "outleft")
			hitLightOutLeft.enabled = true;
		else if (light_name == "outright")
			hitLightOutRight.enabled = true;
		if (light_name != "")
			StartCoroutine(turn_on_all_after_delay());
		light_name = "";

    }

	IEnumerator turn_on_all_after_delay()
	{
		yield return new WaitForSeconds(1f);
		turn_on_all();
	}

	void turn_off_all()
	{
		hitLightSingleLeft.enabled = false;
		hitLightSingleRight.enabled = false;
		hitLightOutLeft.enabled = false;
		hitLightOutRight.enabled = false;
		hitLightDoubleLeft.enabled = false;
		hitLightDoubleRight.enabled = false;
		hitLightTriple.enabled = false;
	}

	void turn_on_all()
	{
		hitLightSingleLeft.enabled = true;
		hitLightSingleRight.enabled = true;
		hitLightOutLeft.enabled = true;
		hitLightOutRight.enabled = true;
		hitLightDoubleLeft.enabled = true;
		hitLightDoubleRight.enabled = true;
		hitLightTriple.enabled = true;
	}
}
