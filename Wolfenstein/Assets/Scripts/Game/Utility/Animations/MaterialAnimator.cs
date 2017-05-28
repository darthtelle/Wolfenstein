using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialAnimator : MonoBehaviour
{
	[SerializeField]
	private Renderer m_Renderer;

	private List<AnimData> m_Queue;

	private MaterialPropertyBlock m_PropertyBlock;
	protected Coroutine m_AnimationCoroutine;

	private void Awake()
	{
		m_PropertyBlock = new MaterialPropertyBlock();
		m_Renderer.GetPropertyBlock(m_PropertyBlock);

		m_Queue = new List<AnimData>();
	}

#region Play Animation

	protected void PlayAnimation(AnimData animation)
	{
		m_AnimationCoroutine.StopCoroutine(this);
		m_AnimationCoroutine = StartCoroutine(UpdateAnimation(animation));
	}

#endregion

#region Queue Animation

	protected void QueueAnimation(AnimData animation)
	{
		m_Queue.Add(animation);
		HandleQueue();
	}

	protected void HandleQueue()
	{
		if((m_AnimationCoroutine == null) && (m_Queue.Count > 0))
		{
			AnimData animation = m_Queue[0];
			m_Queue.RemoveAt(0);

			PlayAnimation(animation);
		}
	}

	protected void ClearQueue()
	{
		m_Queue.Clear();
	}

#endregion

#region Update Animation

	protected IEnumerator UpdateAnimation(AnimData animation)
	{
		int frameIndex = 0;
		int frameCount = animation.GetAnimation.Length;
		float frameLength = animation.GetTime / frameCount;

		while(frameIndex < frameCount)
		{
			Timer timer = new Timer(frameLength);

			m_PropertyBlock.SetTexture("_MainTex", animation.GetAnimation[frameIndex]);
			m_Renderer.SetPropertyBlock(m_PropertyBlock);

			while(timer.Update() == false)
			{
				yield return null;
			}

			frameIndex++;
		}

		m_AnimationCoroutine = null;

		HandleQueue();
	}

#endregion

	[System.Serializable]
	public struct AnimData
	{
		[SerializeField]
		private float m_Time;
		public float GetTime { get { return m_Time; } }

		[SerializeField]
		private Texture[] m_Animation;
		public Texture[] GetAnimation { get { return m_Animation; } }
	}
}
