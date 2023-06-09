using Godot;
using System;

public class Restart : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
 //public override void _Process(float delta)
 //{
	// GetTree().ReloadCurrentScene(); 
  //}
public static bool flag=false;
private void _on_Button_pressed()
{
	//GetTree().ReloadCurrentScene(); 
	GetTree().ChangeScene("res://Level1.tscn");
		flag=true;
	// Replace with function body.
}
}



