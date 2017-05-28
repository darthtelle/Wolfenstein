using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions
{
	public static void SetParent(this GameObject thisGameObject, GameObject parentObject)
	{
		thisGameObject.transform.SetParent(parentObject.transform);
	}

	public static T GetRequiredComponent<T>(this GameObject thisGameObject)
	{
		T component = thisGameObject.GetComponent<T>();

		if(component == null)
		{
			Debug.LogError("ERROR: Could not find component of type " + typeof(T).ToString() + " on " + thisGameObject);
		}

		return component;
	}
}

public static class CoroutineExtensions
{
	public static void StopCoroutine(this Coroutine thisCoroutine, MonoBehaviour monobehaviour)
	{
		if(thisCoroutine != null)
		{
			monobehaviour.StopCoroutine(thisCoroutine);
		}
	}
}

public static class AnimatorExtensions
{
	private static Coroutine m_PlayingCoroutine;

	public static bool IsPlaying(this Animator thisAnimator, string name)
	{
		/*Debug.Log("Coroutine: " + m_PlayingCoroutine + " Name: " + Animator.StringToHash(name) + ": " + thisAnimator.GetCurrentAnimatorStateInfo(0).shortNameHash +
			" Time: " + (thisAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime % thisAnimator.GetCurrentAnimatorStateInfo(0).length) + 
			" IsPlaying: " + ((m_PlayingCoroutine != null) && ((thisAnimator.GetCurrentAnimatorStateInfo(0).IsName(name)) || 
			((thisAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime % thisAnimator.GetCurrentAnimatorStateInfo(0).length) < 1.0f))));*/

		return ((m_PlayingCoroutine != null) || 
			((thisAnimator.GetCurrentAnimatorStateInfo(0).IsName(name)) && 
			((thisAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime % thisAnimator.GetCurrentAnimatorStateInfo(0).length) < 1.0f)));
	}

	public static void SetTrigger(this Animator thisAnimator, MonoBehaviour monobehaviour, string name, string[] animStates, Callback callback)
	{
		if(m_PlayingCoroutine == null)
		{
			m_PlayingCoroutine.StopCoroutine(monobehaviour);
			m_PlayingCoroutine = monobehaviour.StartCoroutine(UpdatePlaying(thisAnimator, animStates, callback));

			thisAnimator.SetTrigger(name);
		}
	}

	private static IEnumerator UpdatePlaying(this Animator thisAnimator, string[] animStates, Callback callback)
	{
		yield return null;

		bool isPlaying = false;

		do
		{
			isPlaying = false;

			for(int animIndex = 0; animIndex < animStates.Length; animIndex++)
			{
				if((thisAnimator.GetCurrentAnimatorStateInfo(0).IsName(animStates[animIndex])) && ((thisAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime % thisAnimator.GetCurrentAnimatorStateInfo(0).length) < 1.0f))
				{
					isPlaying = true;
					break;
				}
			}

			if(isPlaying)
			{
				yield return null;
			}
			else
			{
				break;
			}
		}
		while(isPlaying);

		if(callback != null)
		{
			callback();
		}

		m_PlayingCoroutine = null;
	}
}