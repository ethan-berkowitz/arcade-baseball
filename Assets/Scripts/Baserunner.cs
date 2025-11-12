using UnityEngine;

public class Baserunner : MonoBehaviour
{
    public Vector3 firstPosition = new Vector3(8.06f, 4.62f, -1.67f);
	public Vector3 secondPosition = new Vector3(0f, 5.17f, 6.21f);
	public Vector3 thirdPosition = new Vector3(-8.06f, 4.62f, -1.67f);
	public Vector3 homePosition = new Vector3(0f, 4.04f, -9.66f);
	public Vector3 dugoutPosition = new Vector3(6.08f, 3.75f, -11.58f);
    public float speed = 5.0f;
	public int num_of_moves = 0;

	private string current_position = "home_begin";

    void Update()
    {
        if (current_position == "home_begin" && num_of_moves > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position,
														firstPosition,
														speed * Time.deltaTime);
            if (transform.position == firstPosition)
			{
				current_position = "first";
				num_of_moves--;
			}
        }
		else if (current_position == "first" && num_of_moves > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position,
														secondPosition,
														speed * Time.deltaTime);
            if (transform.position == secondPosition)
			{
                current_position = "second";
				num_of_moves--;
			}
			
        }
		else if (current_position == "second" && num_of_moves > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position,
														thirdPosition,
														speed * Time.deltaTime);
            if (transform.position == thirdPosition)
			{
                current_position = "third";
				num_of_moves--;
			}
        }
		else if (current_position == "third" && num_of_moves > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position,
														homePosition,
														speed * Time.deltaTime);
            if (transform.position == homePosition)
                Destroy(gameObject);
        }
		else if (num_of_moves == -1)
        {
            transform.position = Vector3.MoveTowards(transform.position,
														dugoutPosition,
														speed * Time.deltaTime);
            if (transform.position == dugoutPosition)
                Destroy(gameObject);
        }
    }
}
