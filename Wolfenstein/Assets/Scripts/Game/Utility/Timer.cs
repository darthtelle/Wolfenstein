using System.Collections;
using UnityEngine;

public class Timer
{
	public float m_TimeLimit;
	public float m_Timer;

	public float NormalisedTime { get { return (m_Timer / m_TimeLimit); } }

	public Timer(float timeLimit)
	{
		m_TimeLimit = timeLimit;
		m_Timer = 0.0f;
	}

	public bool Update()
	{
		m_Timer += Time.deltaTime;
		return (m_Timer >= m_TimeLimit);
	}

	public void Reset()
	{
		m_Timer = 0.0f;
	}
}
