using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventManager
{
	private Dictionary<string, Delegate> m_EventList;

	protected EventManager()
	{
		m_EventList = new Dictionary<string, Delegate>();
	}

#region Add Listener

	private void OnAddListener(string eventType)
	{
		if(m_EventList.ContainsKey(eventType) == false)
		{
			m_EventList.Add(eventType, null);
		}
	}

	public void AddListener(string eventType, Callback callback)
	{
		OnAddListener(eventType);
		m_EventList[eventType] = (Callback)m_EventList[eventType] + callback;
	}

	public void AddListener<T>(string eventType, Callback<T> callback)
	{
		OnAddListener(eventType);
		m_EventList[eventType] = (Callback<T>)m_EventList[eventType] + callback;
	}

	public void AddListener<T, U>(string eventType, Callback<T, U> callback)
	{
		OnAddListener(eventType);
		m_EventList[eventType] = (Callback<T, U>)m_EventList[eventType] + callback;
	}

	public void AddListener<T, U, V>(string eventType, Callback<T, U, V> callback)
	{
		OnAddListener(eventType);
		m_EventList[eventType] = (Callback<T, U, V>)m_EventList[eventType] + callback;
	}

	public void AddListener(Enum eventType, Callback callback)
	{
		AddListener(eventType.ToString(), callback);
	}

	public void AddListener<T>(Enum eventType, Callback<T> callback)
	{
		AddListener(eventType.ToString(), callback);
	}

	public void AddListener<T, U>(Enum eventType, Callback<T, U> callback)
	{
		AddListener(eventType.ToString(), callback);
	}

	public void AddListener<T, U, V>(Enum eventType, Callback<T, U, V> callback)
	{
		AddListener(eventType.ToString(), callback);
	}

#endregion

#region Remove Listener

	private void OnRemoveListener(string eventType)
	{
		if(m_EventList.ContainsKey(eventType))
		{
			if(m_EventList[eventType] == null)
			{
				m_EventList.Remove(eventType);
			}
		}
	}

	public void RemoveListener(string eventType, Callback callback)
	{
		if(m_EventList.ContainsKey(eventType))
		{
			m_EventList[eventType] = (Callback)m_EventList[eventType] - callback;
			OnRemoveListener(eventType);
		}
	}

	public void RemoveListener<T>(string eventType, Callback<T> callback)
	{
		if(m_EventList.ContainsKey(eventType))
		{
			m_EventList[eventType] = (Callback<T>)m_EventList[eventType] - callback;
			OnRemoveListener(eventType);
		}
	}

	public void RemoveListener<T, U>(string eventType, Callback<T, U> callback)
	{
		if(m_EventList.ContainsKey(eventType))
		{
			m_EventList[eventType] = (Callback<T, U>)m_EventList[eventType] - callback;
			OnRemoveListener(eventType);
		}
	}

	public void RemoveListener<T, U, V>(string eventType, Callback<T, U, V> callback)
	{
		if(m_EventList.ContainsKey(eventType))
		{
			m_EventList[eventType] = (Callback<T, U, V>)m_EventList[eventType] - callback;
			OnRemoveListener(eventType);
		}
	}

	public void RemoveListener(Enum eventType, Callback callback)
	{
		RemoveListener(eventType.ToString(), callback);
	}

	public void RemoveListener<T>(Enum eventType, Callback<T> callback)
	{
		RemoveListener(eventType.ToString(), callback);
	}

	public void RemoveListener<T, U>(Enum eventType, Callback<T, U> callback)
	{
		RemoveListener(eventType.ToString(), callback);
	}

	public void RemoveListener<T, U, V>(Enum eventType, Callback<T, U, V> callback)
	{
		RemoveListener(eventType.ToString(), callback);
	}

#endregion

#region Trigger

	public void Trigger(string eventType)
	{
		Delegate getCallback;

		if(m_EventList.TryGetValue(eventType, out getCallback))
		{
			Callback callback = (Callback)getCallback;

			if(callback != null)
			{
				callback();
			}
		}
	}

	public void Trigger<T>(string eventType, T arg0)
	{
		Delegate getCallback;

		if(m_EventList.TryGetValue(eventType, out getCallback))
		{
			Callback<T> callback = (Callback<T>)getCallback;

			if(callback != null)
			{
				callback(arg0);
			}
		}
	}

	public void Trigger<T, U>(string eventType, T arg0, U arg1)
	{
		Delegate getCallback;

		if(m_EventList.TryGetValue(eventType, out getCallback))
		{
			Callback<T, U> callback = (Callback<T, U>)getCallback;

			if(callback != null)
			{
				callback(arg0, arg1);
			}
		}
	}

	public void Trigger<T, U, V>(string eventType, T arg0, U arg1, V arg2)
	{
		Delegate getCallback;

		if(m_EventList.TryGetValue(eventType, out getCallback))
		{
			Callback<T, U, V> callback = (Callback<T, U, V>)getCallback;

			if(callback != null)
			{
				callback(arg0, arg1, arg2);
			}
		}
	}

	public void Trigger(Enum eventType)
	{
		Trigger(eventType.ToString());
	}

	public void Trigger<T>(Enum eventType, T arg0)
	{
		Trigger(eventType.ToString(), arg0);
	}

	public void Trigger<T, U>(Enum eventType, T arg0, U arg1)
	{
		Trigger(eventType.ToString(), arg0, arg1);
	}

	public void Trigger<T, U, V>(Enum eventType, T arg0, U arg1, V arg2)
	{
		Trigger(eventType.ToString(), arg0, arg1, arg2);
	}

#endregion
}

public delegate void Callback();
public delegate void Callback<T>(T arg0);
public delegate void Callback<T, U>(T arg0, U arg1);
public delegate void Callback<T, U, V>(T arg0, U arg1, V arg2);