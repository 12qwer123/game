using Godot;
using System;

public class Amount : Node2D
{
	public override void _Ready()
	{
		
	}

	public override void _Process(float delta)
	{
		GetNode<Label>("/root/Level1/Amount/CanvasLayer/Label3").Text = 
		Convert.ToString(PlayerKinematicBody2D.coin); //счет монет
		
		GetNode<Label>("/root/Level1/Amount/CanvasLayer/Label4").Text = 
		Convert.ToString(PlayerKinematicBody2D.crystal);//счет кристалов
		
		var variableValue = PlayerKinematicBody2D._currentAbilityReloadTime;
		if (variableValue<=0) GetNode<Label>("/root/Level1/Amount/CanvasLayer/Label2").Text = "FULL"; 
		else
		GetNode<Label>("/root/Level1/Amount/CanvasLayer/Label2").Text = 
		Convert.ToString(Math.Round(variableValue));  //таймер перезар€дки

        var variableHealth = PlayerKinematicBody2D.health;
		if (variableHealth<0) GetNode<Label>("/root/Level1/Amount/CanvasLayer/Label").Text = "0";
		else
		GetNode<Label>("/root/Level1/Amount/CanvasLayer/Label").Text = 
		Convert.ToString(PlayerKinematicBody2D.health); //HP
	}
}
