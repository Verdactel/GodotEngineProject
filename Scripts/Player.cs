using Godot;
using System;

public class Player : KinematicBody2D
{
	private int score = 0;
	
	private int speed = 120;
	private int jumpForce = 600;
	private int gravity = 800;
	
	Vector2 vel = new Vector2();
	
	private Sprite sprite;
	
	public override void _Ready()
	{
		sprite = GetNode<Sprite>("Sprite");
	}
	
	public override void _PhysicsProcess(float delta)
	{
		vel.y += delta * gravity;
		
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

		vel = MoveAndSlide(vel, Vector2.Up);
	}
}
