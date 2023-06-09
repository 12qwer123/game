using Godot;
using System;

public class Meteorite : KinematicBody2D
{
	private AnimatedSprite _animatedSprite;

	public Vector2 vvv = new Vector2();
	public Vector2 v = new Vector2(0, -1);
	public static int gravity = 0;
	public static bool f = false;
	
	public override void _Process(float delta)
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		_animatedSprite.Play("default");
		if (IsOnFloor()) {f=true;}//gravity
		else vvv.y+=gravity;//gravity    
		MoveAndSlide(vvv, v);
		if (f) QueueFree();
	}
	private void _on_Area2D_body_entered(object body)
	{
		if (body is Player03)
		{
			Player03 v = body as Player03;
			v.Damage();
			v.Dead();
			QueueFree();
		}
	}
}

