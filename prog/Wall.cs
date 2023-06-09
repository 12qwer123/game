using Godot;
using System;

public class Wall : KinematicBody2D
{
	public Vector2 vvv = new Vector2();
	public Vector2 v = new Vector2(0, -1);
	public static int gravity = 0;
	
	public override void _Process(float delta)
 	{
		if (IsOnCeiling()) {vvv.y=0;}//gravity
		 vvv.y+=gravity;//gravity    
		MoveAndSlide(vvv, v);
	}
}
