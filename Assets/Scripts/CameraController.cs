using UnityEngine;

public class CameraController : MonoBehaviour
{
	private enum State { Looking, Returning, Idling }

	public Transform target;
	public float lookingTime;
	public float idlingTime;
	public float returningTime;

	private float timer;
	private float initialTime;
	private State state;
	private Quaternion initialRot;
	private Quaternion lastRot;


	void Start()
	{
		initialRot = transform.rotation;
		state = State.Looking;
		timer = Time.time + lookingTime;
	}

	void LateUpdate()
	{
		switch (state)
		{
			case State.Looking: Looking(); break;
			case State.Returning: Returning(); break;
			case State.Idling: Idling(); break;
		}
	}

	void Looking()
	{
		transform.LookAt(target);

		if (Time.time < timer) return;
		state = State.Idling;
		lastRot = transform.rotation;
		timer = Time.time + idlingTime;
	}

	void Idling()
	{
		if (Time.time < timer) return;
		state = State.Returning;
		initialTime = Time.time;
		timer = initialTime + idlingTime;
	}

	void Returning()
	{
		var t = Mathf.InverseLerp(initialTime, timer, Time.time);
		transform.rotation = Quaternion.Lerp(lastRot, initialRot, t);
	}
}
