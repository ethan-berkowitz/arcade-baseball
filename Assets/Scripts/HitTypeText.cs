using UnityEngine;
using System.Collections;
using TMPro;

public class HitTypeText : MonoBehaviour
{
    public TextMeshProUGUI uiText;
	public Status status;
	private string text = "";
	//int display_time = 30;
	//int display_counter = 0;

    void Start()
    {
		status = FindObjectOfType<Status>();
    }

	void Update()
	{
		if (status.outcome != "") {
			text = status.outcome;
			StartCoroutine(turn_on_all_after_delay());
		}
		uiText.text = text;
	}

	IEnumerator turn_on_all_after_delay()
	{
		yield return new WaitForSeconds(1f);
		text = "";
	}
}