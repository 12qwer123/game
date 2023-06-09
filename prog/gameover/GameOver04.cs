using Godot;
using System;

public class GameOver04 : Node2D
{
	public static bool flag=false;
	
	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://Level04/Level04.tscn");
			flag=true;
	}
	
	private void _on_Button2_pressed()
	{
		GetTree().ChangeScene("res://menu/Menu.tscn");
			flag=true;
	}
}
