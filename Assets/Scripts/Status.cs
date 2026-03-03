using UnityEngine;
using UnityEngine.Events;

public class Status : MonoBehaviour
{
	public RunnerSpawner runnerspawner;
	public uint runs = 0;
	public uint outs = 0;
	public uint strikes = 0;
	public uint inning = 1;
	public bool on_first = false;
	public bool on_second = false;
	public bool on_third = false;
	public string outcome = "";
	public string scoreboard_outcome = "Press 'Enter'";
	public uint max_innings = 3;
	public bool gameover = false;
	public bool ball_in_play = false;

	[Header("Events")]
    public UnityEvent onBallNotInPlay;

    void Start()
    {
		runnerspawner = FindObjectOfType<RunnerSpawner>();
    }

    void Update()
    {
		if (ball_in_play) {
			scoreboard_outcome = "------";
		}
		if (gameover && Input.GetKeyDown(KeyCode.R)) {
            reset_game();
		}

		if (outcome != "" && ball_in_play) {
			ball_in_play = false;
			onBallNotInPlay?.Invoke();
		}
		if (outcome == "out") {
			apply_outs();
		}
		else if (outcome == "strike") {
			scoreboard_outcome = outcome;
			apply_strikes();
		}
		else if (outcome == "single") {
			scoreboard_outcome = outcome;
			apply_single();
		}
		else if (outcome == "double") {
			scoreboard_outcome = outcome;
			apply_double();
		}
		else if (outcome == "triple") {
			scoreboard_outcome = outcome;
			apply_triple();
		}
		else if (outcome == "homerun") {
			scoreboard_outcome = outcome;
			apply_homerun();
		}
		else if (gameover) {
			scoreboard_outcome = "gameover: retry (R)";
		}
		outcome = "";
    }

	void reset_game() {
		gameover = false;
		runs = 0;
		outs = 0;
		strikes = 0;
		inning = 1;
		outcome = "";
		ball_in_play = false;
		on_first = false;
		on_second = false;
		on_third = false;
		scoreboard_outcome = "Press 'Enter'";
	}

	void apply_single() {
		runnerspawner.num_of_moves = 1;
		strikes = 0;
		if (on_first == true)
		{
			if (on_second == true)
			{
				if (on_third == true)
					runs++;
				else
					on_third = true;
			}
			else if (on_third == true)
			{
				runs++;
				on_second = true;
				on_third = false;
			}
			else
				on_second = true;
		}
		else if (on_second == true)
		{
			if (on_third == true)
			{
				runs++;
				on_first = true;
				on_second = false;
			}
			else
			{
				on_first = true;
				on_second = false;
				on_third = true;
			}
		}
		else if (on_third == true)
		{
			runs++;
			on_first = true;
			on_third = false;
		}
		else
			on_first = true;
	}

	void apply_double() {
		runnerspawner.num_of_moves = 2;
		strikes = 0;
		if (on_first)
		{
			if (on_second)
			{
				if (on_third)
					runs += 2;
				else
				{
					runs++;
					on_third = true;
				}
			}
			else if (on_third)
				runs++;
			else
				on_third = true;
		}
		else if (on_second)
		{
			if (on_third)
			{
				runs += 2;
				on_third = false;
			}
			else
				runs++;
		}
		else if (on_third)
		{
			runs++;
			on_third = false;
		}
		on_first = false;
		on_second = true;
	}

	void apply_triple() {
		runnerspawner.num_of_moves = 3;
		strikes = 0;
		if (on_first == true)
			runs++;
		if (on_second == true)
			runs++;
		if (on_third == true)
			runs++;
		clear_bases();
		on_third = true;
	}

	void apply_homerun() {
		runnerspawner.num_of_moves = 4;
		strikes = 0;
		runs++;
		if (on_first == true)
			runs++;
		if (on_second == true)
			runs++;
		if (on_third == true)
			runs++;
		clear_bases();
	}

	void clear_bases() {
		on_first = false;
		on_second = false;
		on_third = false;
	}

	void apply_outs() {
		strikes = 0;
		outs++;
		if (outs == 3)
		{
			runnerspawner.num_of_moves = -1;
			clear_bases();
			if (inning == max_innings) {
				gameover = true;
			}
			else {
				scoreboard_outcome = "end of inning";
				outs = 0;
				inning++;
			}
		}
		else
			scoreboard_outcome = "out";
	}

	void apply_strikes() {
		strikes++;
		if (strikes == 3)
			apply_outs();
	}
}
