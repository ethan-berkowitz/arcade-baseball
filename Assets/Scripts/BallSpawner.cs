using UnityEngine;
using UnityEngine.Events;

public class BallSpawner : MonoBehaviour
{
    public GameObject spherePrefab;   // Assign your prefab in the Inspector
    public Transform spawnPoint;      // Where spheres will spawn
	public Status status;
	public float force = 2500f;
	public float forceRange = 400f;
	public float offsetForce = 0.25f;
	
    [Header("Events")]
    public UnityEvent onBallSpawned;

    public AudioClip releaseBallSFX; 
    private AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

	void Start()
	{
		status = FindObjectOfType<Status>();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !status.ball_in_play && !status.gameover) {
            SpawnSphere();
            audioSource.PlayOneShot(releaseBallSFX);
			status.ball_in_play = true;
		}
    }

    void SpawnSphere()
    {
        onBallSpawned?.Invoke();

        GameObject sphere = Instantiate(spherePrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = sphere.GetComponent<Rigidbody>();

		float randomForceRange = Random.Range(-forceRange, forceRange);
        rb.AddForce(Vector3.back * (force + randomForceRange));
        //Apply small random push
        if (rb != null) {
            Vector3 randomPush = new Vector3(
                Random.Range(-offsetForce, offsetForce),
                0f,
                Random.Range(-offsetForce, offsetForce)
            );
            rb.AddForce(randomPush * 2f, ForceMode.Impulse);
        }
    }
}

