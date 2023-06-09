using Godot;
using System;

public class BoxL01 : Node2D
{
	private AnimatedSprite _animatedSprite;
	
	public static bool flag = false;
	private void _on_Area2D_body_entered(object body)
	{
		if (flag)
		{
			if (body is PlayerKinematicBody2D)
			{
				_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
				_animatedSprite.Play("open");
		
				var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
				m.Stream =GD.Load<AudioStream>("res://звуки/boxxx.wav");
				m.Play();
				PlayerKinematicBody2D v = body as PlayerKinematicBody2D;
				v.PlusCrystal();
				flag=false;
			}
		
			if (body is Player02)
			{
				_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
				_animatedSprite.Play("open");
			
				var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
				m.Stream =GD.Load<AudioStream>("res://звуки/boxxx.wav");
				m.Play();
				Player02 v = body as Player02;
				v.PlusCrystal();
				flag=false;
			}
			
			if (body is Player04)
			{
				_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
				_animatedSprite.Play("open");
			
				var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
				m.Stream =GD.Load<AudioStream>("res://звуки/boxxx.wav");
				m.Play();
				Player04 v = body as Player04;
				v.PlusCrystal();
				flag=false;
			}
		}
	}
}

