using Godot;
using System;

public class hiiit : Node2D
{
	public override void _Ready()
	{
		var area = GetNode<Area2D>("Area2D");
		area.Connect("area_entered",this,"OnCollision");
		area.Connect("body_entered",this,"OnCollision");
	}

	private void OnCollision(Node with)
	{
		GD.Print("!");
		QueueFree();
	}
	
	public void _on_Area2D_body_entered(object body)
	{
		if (body is Vrag)
		{
			Vrag v = body as Vrag;
			v.kill();
		}
		if (body is Vrag01)
		{
			Vrag01 v = body as Vrag01;
			v.kill();
		}
		if (body is Vrag02)
		{
			Vrag02 v = body as Vrag02;
			v.kill();
		}
		//урон темным скелетам
		if (body is DarkSkeleton01)
		{
			DarkSkeleton01 v1v = body as DarkSkeleton01;
			v1v.killDarkSkeleton();
		}
		if (body is DarkSkeleton012)
		{
			DarkSkeleton012 vv = body as DarkSkeleton012;
			vv.killDarkSkeleton();
		}
		if (body is DarkSkeleton02)
		{
			DarkSkeleton02 vv = body as DarkSkeleton02;
			vv.killDarkSkeleton();
		}
		//урон гоблинам
		if (body is Goblin01)
		{
			Goblin01 vvv = body as Goblin01;
			vvv.killGoblin();
		}
		if (body is Goblin012)
		{
			Goblin012 vvv = body as Goblin012;
			vvv.killGoblin();
		}
		if (body is Goblin02)
		{
			Goblin02 vvv = body as Goblin02;
			vvv.killGoblin();
		}
		//урон летучим мышам
		if (body is MutatedBat)
		{
			MutatedBat vvvv = body as MutatedBat;
			vvvv.killMutatedBat();
		}
		if (body is MutatedBat02)
		{
			MutatedBat02 vvvv = body as MutatedBat02;
			vvvv.killMutatedBat();
		}
		//урон Slime
		if (body is Slime)
		{
			Slime vvvv = body as Slime;
			vvvv.kill();
		}
		//урон боссу
		if (body is Boss)
		{
			Boss vvvv = body as Boss;
			vvvv.MinusHP();
			vvvv.Kill();
		}
	}
}
