using Godot;
using System;

public class Amount01 : Node2D
{
	public override void _Process(float delta)
	{
		GetNode<Label>("/root/Level01/Amount01/CanvasLayer/Label3").Text = 
		Convert.ToString(PlayerKinematicBody2D.coin)+"/14"; //счет монет Level01

		GetNode<Label>("/root/Level01/Amount01/CanvasLayer/Label4").Text = 
		Convert.ToString(PlayerKinematicBody2D.crystal)+"/1"; //счет кристалов Level01

		GetNode<Label>("/root/Level01/Amount01/CanvasLayer/Label5").Text = 
		Convert.ToString(PlayerKinematicBody2D.ruby)+"/3"; //счет рубинов Level01

		var variableValue = PlayerKinematicBody2D._currentAbilityReloadTime;
		if (variableValue<=0) GetNode<Label>("/root/Level01/Amount01/CanvasLayer/Label2").Text = "FULL"; 
		else
		GetNode<Label>("/root/Level01/Amount01/CanvasLayer/Label2").Text = 
		Convert.ToString(Math.Round(variableValue)); //таймер перезарядки Level01

		var variableHealth = PlayerKinematicBody2D.health;
		if (variableHealth<0) GetNode<Label>("/root/Level01/Amount01/CanvasLayer/Label").Text = "0";
		else
		GetNode<Label>("/root/Level01/Amount01/CanvasLayer/Label").Text = 
		Convert.ToString(PlayerKinematicBody2D.health); //HP Level01
	}
	
	private void _on_Button_pressed() //кнопка паузы 
	{
		if (GetTree().Paused) GetTree().Paused = false;
		else GetTree().Paused = true;
	}
}
