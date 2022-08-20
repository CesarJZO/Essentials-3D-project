using UnityEngine;

public class PlatformLerp : MonoBehaviour
{
	public float speed;
	public Vector3 offset;

	private Vector3 initialPos;
	private Vector3 a, b;

	void Awake()
	{
		initialPos = transform.position;
		SetOffset();
	}

	void Update()
	{
		var t = Mathf.Sin(Time.time * speed);
		if (t >= 0f)
			transform.position = Vector3.Lerp(initialPos, a, t);
		else
			transform.position = Vector3.Lerp(initialPos, b, -t);

	}

	void OnValidate()
	{
		SetOffset();
	}
	void SetOffset()
	{
		a = initialPos + offset;
		b = initialPos - offset;
	}
}
