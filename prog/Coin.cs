using Godot;
using System;

public class Coin : Node2D
{
	private AnimatedSprite _animatedSprite;
	public int a;
	
	public override void _Process(float delta)
	{ 
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		_animatedSprite.Play("default");
		 a=PlayerKinematicBody2D.coin;
	}
	
	private void _on_Area2D_body_entered(object body)
	{
		if (body is PlayerKinematicBody2D)
		{
			PlayerKinematicBody2D v = body as PlayerKinematicBody2D;
			v.PlusCoin();
			QueueFree();
		}
		if (body is Player02)
		{
			Player02 v = body as Player02;
			v.PlusCoin();
			QueueFree();
		}
		if (body is Player04)
		{
			Player04 v = body as Player04;
			v.PlusCoin();
			QueueFree();
		}
	}
}

