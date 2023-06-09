using Godot;
using System;

public class LifePlus : Node2D
{
	public int hp;
	public int hpPlayer2;
	
	public override void _Process(float delta)
	{ 
		hp=PlayerKinematicBody2D.health;
		hpPlayer2=Player02.health;
	}
	
	private void _on_Area2D_body_entered(object body)
	{
		if (body is PlayerKinematicBody2D)
		{
			PlayerKinematicBody2D v = body as PlayerKinematicBody2D;
			v.PlusHP();
			
			if (hp!=300) QueueFree();
		}
		if (body is Player02)
		{
			Player02 v = body as Player02;
			v.PlusHP();
			
			if (hpPlayer2!=300) QueueFree();
		}
	}
}



