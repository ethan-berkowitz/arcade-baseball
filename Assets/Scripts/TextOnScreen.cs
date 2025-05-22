using TMPro;
using UnityEngine;

public class TextOnScreen : MonoBehaviour
{
    public TextMeshProUGUI textElement;
	public Status status;

    void Start()
    {
        textElement.text = "Single: " + status.hit_single.ToString() + "\n" +
							"Double: " + status.hit_double.ToString() + "\n" +
							"Triple: " + status.hit_triple.ToString() + "\n" +
							"Out: " + status.hit_out.ToString();
    }

	void Update()
	{
        textElement.text = "Single: " + status.hit_single.ToString() + "\n" +
							"Double: " + status.hit_double.ToString() + "\n" +
							"Triple: " + status.hit_triple.ToString() + "\n" +
							"Out: " + status.hit_out.ToString();
	}
}
