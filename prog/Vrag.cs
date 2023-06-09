using Godot;
using System;

public class Vrag : KinematicBody2D
{
	private AnimatedSprite _animatedSprite;
	public float speed =50;
	public int Gravity = 5;
	public Vector2 Upp = new Vector2(0, -1);
	public Vector2 vvv = new Vector2();
	public bool activ=true;
	public bool flagHit = false;

	public void kill()
	{
		var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
			m.Stream =GD.Load<AudioStream>("res://звуки/die2_monster.wav");
			m.Play();
			
		var ff=GetNode<CollisionShape2D>("CollisionShape2D");
		var de = GetNode<CollisionShape2D>("DeadColl");

		var node = new CollisionShape2D();
		ff.SetDeferred("disabled", true);
		de.SetDeferred("disabled", false);
		
		activ =false;
		vvv.x=0;
		_animatedSprite.Play("dead");
	}
	
 	public override void _Process(float delta)
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		if (activ==true)
		{
			if (IsOnWall()) speed *= (-1);
			vvv.x=speed;
		}
	 	if (IsOnFloor()) vvv.y=0;//gravity
		else vvv.y+=Gravity;//gravity
		
		if (flagHit==true) return;
		
		MoveAndSlide(vvv, Upp);

		var c1=GetNode<CollisionShape2D>("/root/Level1/Vrag/Area2D/CollisionShape2D");
		var c2 = GetNode<CollisionShape2D>("/root/Level1/Vrag/Area2D/CollisionShape2D2");
		
		
		//animated
		if (vvv.x > 0 && flagHit==false)
		{
			c1.SetDeferred("disabled", false);
			c2.SetDeferred("disabled", true);

			_animatedSprite.Play("walk");//вправо
			_animatedSprite.FlipH = false;
		}
		else if (vvv.x < 0 && flagHit==false)
		{
			c1.SetDeferred("disabled", true);
			c2.SetDeferred("disabled", false);

			_animatedSprite.Play("walk");//влево
			_animatedSprite.FlipH = true;
		}
	}
	
	private void _on_AnimatedSprite_animation_finished()
	{
		if (_animatedSprite.Animation=="hit")
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
			_animatedSprite.Play("hit");
			PlayerKinematicBody2D v = body as PlayerKinematicBody2D;
			v.Damage();
			v.Dead();
		}
	}
}
