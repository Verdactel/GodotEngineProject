using Godot;
using System;

public class Player : KinematicBody2D
{
	private int score = 0;
	
	private int speed = 120;
	private int jumpForce = 300;
	private int gravity = 800;
	
	Vector2 vel = new Vector2();
	
	private Sprite sprite;
	
	public override void _Ready()
	{
		sprite = GetNode<Sprite>("Sprite");
	}
	
	public override void _PhysicsProcess(float delta)
	{
		if(Input.IsActionPressed("move_left"))
		{
			vel.x = -speed;
		}
		else if(Input.IsActionPressed("move_right"))
		{
			vel.x = speed;
		}
		else
		{
			vel.x = 0;
		}
		
		// var motion = vel * delta;
		// MoveAndCollide(motion);

		//Applying velocity
		vel = MoveAndSlide(vel, Vector2.Up);
		
		//gravity
		vel.y += gravity * delta;

		//jump
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			vel.y -= jumpForce;
		}

		//Flip sprite direction
		if(vel.x < 0)
			sprite.FlipH = true;
		else if (vel.x > 0)
			sprite.FlipH = false;
	}
}
