using Godot;
using System;

public class GameOver : Node2D
{
	public static bool flag=false;
	
	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://Level01/Level01.tscn");
			flag=true;
	}
	
	private void _on_Button2_pressed()
	{
		GetTree().ChangeScene("res://menu/Menu.tscn");
			flag=true;
	}
}






