using Godot;
using System;

public class GameOver02 : Node2D
{
	public static bool flag=false;
	
	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://Level02/Level02.tscn");
			flag=true;
	}
	
	private void _on_Button2_pressed()
	{
		GetTree().ChangeScene("res://menu/Menu.tscn");
			flag=true;
	}
}


