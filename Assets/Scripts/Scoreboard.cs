using UnityEngine;
using System.Collections;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI uiText;
	public Status status;

    void Start() {
		status = FindObjectOfType<Status>();
    }

	void Update() {

		uiText.color = Color.white;
		uiText.text = "Runs: " + status.runs.ToString()
						+ "   Inning: " + status.inning.ToString()
						+ "\nOuts: " + status.outs.ToString()
						+ "   Strikes: " + status.strikes.ToString()
						+ "\n" + status.scoreboard_outcome;
	}
}
