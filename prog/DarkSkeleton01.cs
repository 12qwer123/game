using Godot;
using System;

public class DarkSkeleton01 : KinematicBody2D
{
	private AnimatedSprite _animatedSprite;
	public float speed =50;
	public int Gravity = 5;
	public Vector2 up = new Vector2(0, -1);
	public Vector2 vector = new Vector2();
	public bool activ=true;
	public bool flagHit = false;

	public void killDarkSkeleton()
	{
		var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
			m.Stream =GD.Load<AudioStream>("res://звуки/roar_monster.wav");
			m.Play();
		var ff=GetNode<CollisionShape2D>("CollisionShape2D");
		var de = GetNode<CollisionShape2D>("DeadColl");
		var node = new CollisionShape2D();
		ff.SetDeferred("disabled", true);
		de.SetDeferred("disabled", false);
		activ =false;
		vector.x=0;
		_animatedSprite.Play("Dead");
	}
	
 	public override void _Process(float delta)
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		if (activ==true)
		{
			if (IsOnWall()) speed *= (-1);
			vector.x=speed;
		}
	 	if (IsOnFloor()) vector.y=0;//gravity
		else vector.y+=Gravity;//gravity
		if (flagHit==true) return;
		MoveAndSlide(vector, up);
		
		
		
		var c1=GetNode<CollisionShape2D>("/root/Level01/DarkSkeleton01/Area2D/CollisionShape2D");
		var c2 = GetNode<CollisionShape2D>("/root/Level01/DarkSkeleton01/Area2D/CollisionShape2D2");
		

		//animated
		if (vector.x > 0 && flagHit==false)
		{
			c1.SetDeferred("disabled", false);
			c2.SetDeferred("disabled", true);
			
			_animatedSprite.Play("Walk");//вправо
			_animatedSprite.FlipH = false;
		}
		else if (vector.x < 0 && flagHit==false)
		{
			c1.SetDeferred("disabled", true);
			c2.SetDeferred("disabled", false);
			
			_animatedSprite.Play("Walk");//влево
			_animatedSprite.FlipH = true;
		}
	}
	
	private void _on_AnimatedSprite_animation_finished()
	{
		if (_animatedSprite.Animation=="Hit")
		flagHit = false;
	}
	
	private void _on_Area2D_body_entered(object body)
	{
		if ((body is PlayerKinematicBody2D) && activ)
		{
			var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
			m.Stream =GD.Load<AudioStream>("res://звуки/attack_monster.wav");
			m.Play();
			flagHit = true;
			_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
			_animatedSprite.Play("Hit");
			PlayerKinematicBody2D v = body as PlayerKinematicBody2D;
			v.Damage();
			v.Dead();
		}
	}
}

