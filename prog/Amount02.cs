using Godot;
using System;

public class Amount02 : Node2D
{
	public override void _Process(float delta)
	{
		GetNode<Label>("/root/Level02/Amount02/CanvasLayer/Label3").Text = 
		Convert.ToString(Player02.coin)+"/12"; //счет монет Level02

		GetNode<Label>("/root/Level02/Amount02/CanvasLayer/Label4").Text = 
		Convert.ToString(Player02.crystal)+"/1"; //счет кристалов Level02

		GetNode<Label>("/root/Level02/Amount02/CanvasLayer/Label5").Text = 
		Convert.ToString(Player02.ruby)+"/3"; //счет рубинов Level02

		var variableValue = Player02._currentAbilityReloadTime;
		if (variableValue<=0) GetNode<Label>("/root/Level02/Amount02/CanvasLayer/Label2").Text = "FULL"; 
		else
		GetNode<Label>("/root/Level02/Amount02/CanvasLayer/Label2").Text = 
		Convert.ToString(Math.Round(variableValue)); //таймер перезарядки Level02

		var variableHealth = Player02.health;
		if (variableHealth<0) GetNode<Label>("/root/Level02/Amount02/CanvasLayer/Label").Text = "0";
		else
		GetNode<Label>("/root/Level02/Amount02/CanvasLayer/Label").Text = 
		Convert.ToString(Player02.health); //HP Level02
	}

	private void _on_Button_pressed() //кнопка паузы
	{
		if (GetTree().Paused) GetTree().Paused = false;
		else GetTree().Paused = true;
	}
}
