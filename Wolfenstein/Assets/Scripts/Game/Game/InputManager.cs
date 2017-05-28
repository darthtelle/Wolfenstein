using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
	[SerializeField]
	private KeyCode m_WalkForward = KeyCode.UpArrow;

	[SerializeField]
	private KeyCode m_WalkBackward = KeyCode.DownArrow;

	[SerializeField]
	private KeyCode m_MoveLeft = KeyCode.LeftArrow;

	[SerializeField]
	private KeyCode m_MoveRight = KeyCode.RightArrow;

	[SerializeField]
	private KeyCode m_Shoot = KeyCode.LeftControl;

	[SerializeField]
	private KeyCode m_Use = KeyCode.Space;

	[SerializeField]
	private KeyCode m_Strafe = KeyCode.LeftAlt;

	[SerializeField]
	private KeyCode m_Run = KeyCode.RightControl;

	public bool IsWalkForward { get { return Input.GetKey(m_WalkForward); } }
	public bool IsWalkBackward { get { return Input.GetKey(m_WalkBackward); } }

	public bool IsMoveLeft { get { return Input.GetKey(m_MoveLeft); } }
	public bool IsMoveRight { get { return Input.GetKey(m_MoveRight); } }

	public bool IsShoot { get { return Input.GetKey(m_Shoot); } }
	public bool IsUse { get { return Input.GetKeyDown(m_Use); } }
	public bool IsStrafe { get { return Input.GetKey(m_Strafe); } }
	public bool IsRun { get { return Input.GetKey(m_Run); } }
}
