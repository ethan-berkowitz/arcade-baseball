using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject spherePrefab;   // Assign your prefab in the Inspector
    public Transform spawnPoint;      // Where spheres will spawn
	public float force = 30f;
	public float offsetForce = 0.3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            SpawnSphere();
    }

    void SpawnSphere()
    {
        GameObject sphere = Instantiate(spherePrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody rb = sphere.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.back * force);

        //Apply small random push
        if (rb != null)
        {
            Vector3 randomPush = new Vector3(
                Random.Range(-offsetForce, offsetForce),
                0f,
                Random.Range(-offsetForce, offsetForce)
            );
            rb.AddForce(randomPush * 2f, ForceMode.Impulse);
        }
    }
}

