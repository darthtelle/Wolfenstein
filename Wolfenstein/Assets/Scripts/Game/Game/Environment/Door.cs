using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	private const float k_DoorTimer = 5.0f;
	private const float k_DoorSpeed = 5.0f;

	[SerializeField]
	private GameObject m_DoorObject;

	private Coroutine m_InteractCoroutine;
	private Coroutine m_TimerCoroutine;
	private bool m_IsOpen;

	private void Awake()
	{
		m_IsOpen = false;
	}

	private void OnTriggerStay()
	{
		if(InputManager.Instance.IsUse)
		{
			OpenDoor(!m_IsOpen);
		}
	}

	private void OpenDoor(bool open)
	{
		m_IsOpen = open;

		m_TimerCoroutine.StopCoroutine(this);
		m_TimerCoroutine = null;

		m_InteractCoroutine.StopCoroutine(this);
		m_InteractCoroutine = StartCoroutine(UpdateDoorOpen(open));
	}

	private IEnumerator UpdateDoorOpen(bool open)
	{
		Vector3 startPosition = m_DoorObject.transform.localPosition;
		Vector3 targetPosition = Vector3.zero;

		if(open)
		{
			targetPosition = new Vector3(-1.0f, 0.0f, 0.0f);
		}
		else
		{
			targetPosition = Vector3.zero;
		}

		float distance = Vector3.Distance(startPosition, targetPosition);
		while(distance > 0.1f)
		{
			m_DoorObject.transform.localPosition = Vector3.MoveTowards(m_DoorObject.transform.localPosition, targetPosition, Time.deltaTime * k_DoorSpeed);
			distance = Vector3.Distance(m_DoorObject.transform.localPosition, targetPosition);

			yield return null;
		}

		m_DoorObject.transform.localPosition = targetPosition;

		// Check whether the door was opened.
		if(open)
		{	
			// If it was, start the timer.
			m_TimerCoroutine = StartCoroutine(UpdateDoorTimer());
		}
	}

	private IEnumerator UpdateDoorTimer()
	{
		float timer = 0.0f;
		while(timer <= k_DoorTimer)
		{
			timer += Time.deltaTime;
			yield return null;
		}

		Vector3 center = gameObject.transform.position + new Vector3(0.0f, gameObject.transform.localScale.y * 0.5f, 0.0f);
		Vector3 halfExtents = gameObject.transform.localScale * 0.45f;
		int layerMask = ~(1 << LayerMask.NameToLayer("Door"));

		Collider[] colliders = null;

		// Check nothing is blocking the door from closing.
		do
		{
			colliders = Physics.OverlapBox(center, halfExtents, gameObject.transform.rotation, layerMask);
			yield return null;
		}
		while((colliders != null) && (colliders.Length > 0));

		// Close the door.
		OpenDoor(false);
	}
}
