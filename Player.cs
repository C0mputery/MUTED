using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using Godot;

public partial class Player : CharacterBody3D {
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;

	public override void _Ready() { InputSystem.Jump.Pressed += Jump; }
	public override void _ExitTree() { InputSystem.Jump.Pressed -= Jump; }

	private bool ShouldJump = false;
	public void Jump() { ShouldJump = true; }
	
	public override void _PhysicsProcess(double delta) {
		Vector3 velocity = Velocity;
		
		// Add the gravity.
		if (!IsOnFloor()) {
			velocity += GetGravity() * (float)delta;
		}
		
		if (ShouldJump && IsOnFloor()) {
			velocity.Y = JumpVelocity;
			ShouldJump = false;
		}

		Vector2 inputDir = InputSystem.GetMovementInput();
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero) {
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		} else {
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
