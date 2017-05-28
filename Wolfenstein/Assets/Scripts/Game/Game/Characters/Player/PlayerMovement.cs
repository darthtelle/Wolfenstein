using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private const float k_WalkSpeed = 5.0f;
	private const float k_RunSpeed = 10.0f;
	private const float k_TurnSpeed = 75.0f;

	private enum State
	{
		None,
		Walking,
		Running	
	};

	private CharacterController m_CharacterController;

	private State m_MoveState;

	public bool IsWalking { get { return m_MoveState == State.Walking; } }
	public bool IsRunning { get { return m_MoveState == State.Running; } }

	private void Awake()
	{
		m_CharacterController = gameObject.GetComponent<CharacterController>();
	}

	public void UpdateMovement()
	{
		// Reset the move state.
		m_MoveState = State.None;

		Vector3 speed = Vector3.zero;
		bool isRunning = InputManager.Instance.IsRun;

		// Update player movement.
		if(InputManager.Instance.IsWalkForward)
		{
			// Move forward.
			speed.z = 1.0f * (isRunning ? k_RunSpeed : k_WalkSpeed);

			// Update the move state depending on whether the player is running or walking.
			m_MoveState = isRunning ? State.Running : State.Walking;
		}
		else if(InputManager.Instance.IsWalkBackward)
		{
			// Move backward.
			speed.z = -1.0f * (isRunning ? k_RunSpeed : k_WalkSpeed);

			// Update the move state depending on whether the player is running or walking.
			m_MoveState = isRunning ? State.Running : State.Walking;
		}

		if(InputManager.Instance.IsStrafe)
		{
			// Update strafing.
			if(InputManager.Instance.IsMoveLeft)
			{
				// Strafe left.
				speed.x = -1.0f * (isRunning ? k_RunSpeed : k_WalkSpeed);
			}
			else if(InputManager.Instance.IsMoveRight)
			{
				// Strafe right.
				speed.x = 1.0f * (isRunning ? k_RunSpeed : k_WalkSpeed);
			}
		}
		else
		{
			// Update player rotation.
			if(InputManager.Instance.IsMoveLeft)
			{
				// Rotate left.
				gameObject.transform.Rotate(Vector3.up, -k_TurnSpeed * Time.deltaTime);
			}
			else if(InputManager.Instance.IsMoveRight)
			{
				// Rotate right.
				gameObject.transform.Rotate(Vector3.up, k_TurnSpeed * Time.deltaTime);
			}
		}

		// Multiply player movement by the objects rotation so the character moves in the forward direction
		speed = gameObject.transform.rotation * speed;

		// Update character controller (frame independent)
		m_CharacterController.SimpleMove(speed);
	}
}
