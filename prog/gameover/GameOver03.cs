using Godot;
using System;

public class GameOver03 : Node2D
{
	public static bool flag=false;

	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://Level03/Level03.tscn");
			flag=true;
		Boss.Hp=1500;
	}

	private void _on_Button2_pressed()
	{
		GetTree().ChangeScene("res://menu/Menu.tscn");
			Boss.Hp=1500;
	}
}



