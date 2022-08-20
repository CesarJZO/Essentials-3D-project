using UnityEngine;

public class BallTransform : MonoBehaviour
{
	public Vector3 scale;

	void Update()
	{
		transform.localScale += scale * Time.deltaTime;
	}
}
