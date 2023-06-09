using Godot;
using System;

public class DangerousArea : Node2D
{
	
	private void _on_Area2D_body_entered(object body)
	{
		if (body is PlayerKinematicBody2D)
		{
			PlayerKinematicBody2D v = body as PlayerKinematicBody2D;
			v.MinusHP();
			v.Dead();
		}
		if (body is Player02)
		{
			Player02 v = body as Player02;
			v.MinusHP();
			v.Dead();
		}
		if (body is Player04)
		{
			Player04 v = body as Player04;
			v.MinusHP();
			v.Dead();
		}
	}
}



