using UnityEngine;

public class RunnerSpawner : MonoBehaviour
{
    public GameObject baserunnerPrefab;
    public Vector3 spawnPoint = new Vector3(0f, 4.04f, -9.66f);
	public int num_of_moves = 0;

    void Update()
    {
        if (num_of_moves > 0)
        {
            // Update all existing baserunners
            Baserunner[] runners = FindObjectsOfType<Baserunner>();
            foreach (Baserunner runner in runners)
            {
                runner.num_of_moves = num_of_moves;
            }

            // Set the value for the next runner to be spawned
            GameObject newRunner = Instantiate(baserunnerPrefab, spawnPoint, Quaternion.identity);
            Baserunner newBaserunnerScript = newRunner.GetComponent<Baserunner>();
            if (newBaserunnerScript != null)
            {
                newBaserunnerScript.num_of_moves = num_of_moves;
            }

            // Reset num_of_moves after applying
            num_of_moves = 0;
        }
		else if (num_of_moves == -1)
		{
            Baserunner[] runners = FindObjectsOfType<Baserunner>();
            foreach (Baserunner runner in runners)
            {
                runner.num_of_moves = num_of_moves;
            }
			num_of_moves = 0;
		}
    }
}
