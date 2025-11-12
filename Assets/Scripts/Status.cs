using UnityEngine;

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
	public uint max_innings = 3;
	public bool gameover = false;
	public bool ball_in_play = false;

    void Start()
    {
		runnerspawner = FindObjectOfType<RunnerSpawner>();
    }

    void Update()
    {
		if (outcome != "")
			ball_in_play = false;
		if (outcome == "out")
			check_outs();
		else if (outcome == "strike")
			check_strikes();
		else if (outcome == "single")
			check_single();
		else if (outcome == "double")
			check_double();
		else if (outcome == "triple")
			check_triple();
		else if (outcome == "homerun")
			check_homerun();
		outcome = "";
    }

	void check_single() {
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

	void check_double() {
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

	void check_triple() {
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

	void check_homerun() {
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

	void check_outs() {
		strikes = 0;
		outs++;
		if (outs == 3)
		{
			outs = 0;
			inning++;
			runnerspawner.num_of_moves = -1;
			clear_bases();
		}
		if (inning > max_innings)
			gameover = true;
	}

	void check_strikes() {
		strikes++;
		if (strikes == 3)
			check_outs();
	}
}
