using Godot;
using System;

public class FinishBad : Node2D
{
	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://menu/Menu.tscn");
	}
}



