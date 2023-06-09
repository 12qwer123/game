using Godot;
using System;

public class Menu : Node2D
{
	private void _on_Button_pressed()
	{
		GetTree().ChangeScene("res://menu/Levels.tscn"); //переход на выбор уровней
	}
	
	private void _on_Button2_pressed()
	{
		GetTree().Quit(); //выход
	}
}
