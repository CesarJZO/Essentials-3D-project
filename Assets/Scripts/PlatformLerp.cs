using UnityEngine;

public class PlatformLerp : MonoBehaviour
{
	public float speed;
	public Vector3 offset;

	private Vector3 initialPos;
	private Vector3 finalPos;

	void Awake()
	{
		initialPos = transform.position;
		finalPos = initialPos + offset;
	}

	void Update()
	{
		var t = Mathf.Sin(Time.time * speed);
		transform.position = Vector3.LerpUnclamped(initialPos, finalPos, t);
	}

	void OnValidate()
	{
		finalPos = initialPos + offset;
	}
}
