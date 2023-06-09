using Godot;
using System;

public class Plarform2 : KinematicBody2D
{
	public float speed =150;
	public Vector2 Upp = new Vector2(0, -1);
	public Vector2 vvv = new Vector2();
	public bool activ=true;
	
	public override void _Process(float delta)
 	{
		if (activ==true)
		{
			if (IsOnWall()) speed *= (-1);
			vvv.x=speed;
		}
		MoveAndSlide(vvv, Upp);
	}
}
