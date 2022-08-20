using UnityEngine;

public class Spinner : MonoBehaviour
{
	public float speed;

	void Update()
	{
		transform.Rotate(0, speed * Time.deltaTime, 0);
	}
}
