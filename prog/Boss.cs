using Godot;
using System;

public class Boss : KinematicBody2D
{
	private AnimatedSprite _animatedSprite;
	public float speed =200;
	public int Gravity = 5;
	public Vector2 up = new Vector2(0, -1);
	public Vector2 vector = new Vector2();
	public int f = 1;
	public bool activ=true;
	public bool flagHit1 = false;
	public bool flagHit = false;
	public static int Hp = 1500;
	public static bool flagKill = false;

	public void Kill()
	{
		if (Hp <= 0)
		{
			_animatedSprite.Play("death");
			var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
			m.Stream = GD.Load<AudioStream>("res://звуки/die2_monster.wav");
			m.Play();

			var ff = GetNode<CollisionShape2D>("CollisionShape2D");
			var de = GetNode<CollisionShape2D>("DeadColl");
;
			ff.SetDeferred("disabled", true);
			de.SetDeferred("disabled", false);

			activ = false;
			vector.x = 0;
			flagKill = true;
		}
	}
	
	public void MinusHP()=>Hp-=100;
	
	public void MinusHPAbility()=>Hp-=150;
	
	public float flagTime = 0.0f;
	public bool flagF=true;
	
 	public override void _Process(float delta)
	{
		var collision1 = GetNode<CollisionShape2D>("/root/Level03/Boss/Area2D/CollisionShape2D");
		var collision2 = GetNode<CollisionShape2D>("/root/Level03/Boss/Area2D/CollisionShape2D2");
		var collision3 = GetNode<CollisionShape2D>("/root/Level03/Boss/Area2D/CollisionShape2D3");
		
		if (Hp <=1100) 
		{
			Meteorite.gravity=2;
			Meteorite2.gravity=2; //выпускает метеориты 1 этап
			Meteorite3.gravity=2;
		}
		if (Hp <=700) 
		{
			Meteorite4.gravity=2;
			Meteorite5.gravity=2;//выпускает метеориты 2 этап
			Meteorite6.gravity=2;
			Meteorite7.gravity=2;
		}
		if (Hp <=500) 
		{
			Meteorite8.gravity=2;
			Meteorite9.gravity=2;//выпускает метеориты 3 этап
			Meteorite10.gravity=2;
			Meteorite11.gravity=2;
			Meteorite12.gravity=2;
		}
		if (Hp<=150) 
		{
			GetNode<Label>("/root/Level03/Boss/Label").Text ="Пощади меня!!!";
			collision1.SetDeferred("disabled", true);
			collision2.SetDeferred("disabled", true);
			collision3.SetDeferred("disabled", true);
			vector.x=0;
			Wall.gravity=-2;// поднимает стену
			activ=false;
		} 
		
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		
		if (activ==true)
		{
			if (vector.x!=0)
			{
				if (IsOnWall()) 
				{
					flagTime=3.0f;
					speed *= (-1);
				}
			}
			if (flagTime>=2.5f||flagTime<=0.0f) vector.x=speed; 
			else vector.x=0;
		}
		if (vector.x==0) collision3.SetDeferred("disabled", true); 
		else collision3.SetDeferred("disabled", false);

		if (flagTime > 0.0f)
		{
			collision1.SetDeferred("disabled", true);
			collision2.SetDeferred("disabled", true);
			_animatedSprite.Play("New Anim");
			flagTime -= delta;
		}
			
	 	if (IsOnFloor()) vector.y=0;//gravity
		else vector.y+=Gravity;//gravity
		
		if (flagHit==true) return;
		
		MoveAndSlide(vector, up);
		if (activ == true)
		{
			//animated
			if (vector.x > 0 && flagHit == false)
			{
				collision1.SetDeferred("disabled", false);
				collision2.SetDeferred("disabled", true);

				_animatedSprite.Play("run");//вправо
				_animatedSprite.FlipH = false;
			}
			else if (vector.x < 0 && flagHit == false)
			{
				collision1.SetDeferred("disabled", true);
				collision2.SetDeferred("disabled", false);

				_animatedSprite.Play("run");//влево
				_animatedSprite.FlipH = true;
			}
		}
	}
	
	private void _on_AnimatedSprite_animation_finished()
	{
		if (_animatedSprite.Animation=="attack")
			flagHit = false;
	}
	
	private void _on_Area2D_body_entered(object body)
	{
		if ((body is Player03) && activ)
		{
			var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
			m.Stream =GD.Load<AudioStream>("res://звуки/attack_monster.wav");
			m.Play();

			flagHit = true;
			_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
			_animatedSprite.Play("attack");
			Player03 v = body as Player03;
			v.Damage();
			v.Dead();
		}
	}
}


