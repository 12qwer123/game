using Godot;
using System;

public class Key : Node2D
{
	private AnimatedSprite _animatedSprite;
	
	public override void _Process(float delta)
	{ 
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		_animatedSprite.Play("default");//запуск анимации
		 
	}
	
	private void _on_Area2D_body_entered(object body)
	{
		if (body is PlayerKinematicBody2D)
		{
			BoxL01.flag=true; //получаем возможность открыть сундук Level01
			PlayerKinematicBody2D v = body as PlayerKinematicBody2D;
			v.KeyMus();
			QueueFree();
		}
		if (body is Player02)
		{
			BoxL01.flag=true;//получаем возможность открыть сундук Level02
			Player02 v = body as Player02;
			v.KeyMus(); //запуск звука
			QueueFree();
		}
		if (body is Player04)
		{
			BoxL01.flag=true;//получаем возможность открыть сундук Level02
			Player04 v = body as Player04;
			v.KeyMus(); //запуск звука
			QueueFree();
		}
	}
}
