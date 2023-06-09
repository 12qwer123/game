using Godot;
using System;

public class Ruby : Node2D
{
	private AnimatedSprite _animatedSprite;
	
	public override void _Process(float delta)
	{ 
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		_animatedSprite.Play("default");
	}
	
	private void _on_Area2D_body_entered(object body)
	{
		if (body is PlayerKinematicBody2D)
		{
			PlayerKinematicBody2D v = body as PlayerKinematicBody2D;
			v.PlusRuby();
			QueueFree();
		}
		if (body is Player02)
		{
			Player02 v = body as Player02;
			v.PlusRuby();
			QueueFree();
		}
		if (body is Player04)
		{
			Player04 v = body as Player04;
			v.PlusRuby();
			QueueFree();
		}
	}
}
