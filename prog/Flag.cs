using Godot;
using System;

public class Flag : Node2D
{
	private AnimatedSprite _animatedSprite;
	public static bool flagF = false;

	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		_animatedSprite.Play("flag");
	}

	public override void _Process(float delta)
	{
		if (flagF)
		{
			flagF = false;
			GetTree().ChangeScene("res://Level02/Level02.tscn"); //переход на следующий уровень
		}
	}

	private void _on_Area2D_body_entered(object body)
	{
		if (body is PlayerKinematicBody2D)
		{
			if (PlayerKinematicBody2D.crystal == 1)
			{
				_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
				_animatedSprite.Play("flagEffects");

				var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
				m.Stream = GD.Load<AudioStream>("res://звуки/jg-032316-sfx-time-machine-takeoff-7_UWav2k52.wav");
				m.Play();

				PlayerKinematicBody2D v = body as PlayerKinematicBody2D;
				v.Transition();
				v.Reset();
			}

		}

	}
}



