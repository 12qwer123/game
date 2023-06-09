using Godot;
using System;

public class Levels : Node2D
{
	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://Level01/Level01.tscn");
	}

	private void _on_Button2_pressed()
	{
		GetTree().ChangeScene("res://Level02/Level02.tscn");
	}

	private void _on_Button3_pressed()
	{
		GetTree().ChangeScene("res://Level04/Level04.tscn");
	}
	
	private void _on_Button4_pressed()
	{
		GetTree().ChangeScene("res://Level03/Level03.tscn");
	}
}






