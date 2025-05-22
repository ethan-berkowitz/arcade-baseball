using UnityEngine;

public class LightToggle : MonoBehaviour
{
    public Light hitLightSingleLeft;
	public Light hitLightSingleRight;
	public Light hitLightOutLeft;
	public Light hitLightOutRight;
	public Light hitLightDoubleLeft;
	public Light hitLightDoubleRight;
	public Light hitLightTriple;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            hitLightSingleLeft.enabled = false;
			hitLightSingleRight.enabled = false;
			hitLightOutLeft.enabled = false;
			hitLightOutRight.enabled = false;
			hitLightDoubleLeft.enabled = false;
			hitLightDoubleRight.enabled = false;
			hitLightTriple.enabled = false;
        }
    }
}
