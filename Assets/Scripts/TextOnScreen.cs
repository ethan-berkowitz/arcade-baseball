using TMPro;
using UnityEngine;

public class TextOnScreen : MonoBehaviour
{
    public TextMeshProUGUI textElement;
	public Status status;

    void Start()
	{
        textElement.text = "First: " + status.on_first.ToString() + "\n" +
							"Second: " + status.on_second.ToString() + "\n" +
							"Third: " + status.on_third.ToString() + "\n" +
							"Runs: " + status.runs.ToString() + "\n" +
							"Strikes: " + status.strikes.ToString() + "\n" +
							"Outs: " + status.outs.ToString()  + "\n" +
							"Inning: " + status.inning.ToString()  + "\n" +
							"Outcome: " + status.outcome;
	}

	void Update()
	{
        textElement.text = "First: " + status.on_first.ToString() + "\n" +
							"Second: " + status.on_second.ToString() + "\n" +
							"Third: " + status.on_third.ToString() + "\n" +
							"Runs: " + status.runs.ToString() + "\n" +
							"Strikes: " + status.strikes.ToString() + "\n" +
							"Outs: " + status.outs.ToString()  + "\n" +
							"Inning: " + status.inning.ToString()  + "\n" +
							"Outcome: " + status.outcome;
	}
}
