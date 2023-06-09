using Godot;
using System;

public class MutatedBat : KinematicBody2D
{
	private AnimatedSprite _animatedSprite;
	public float speed =85;
	public int Gravity = 150;
	public Vector2 Upp = new Vector2(0, -1);
	public Vector2 vvv = new Vector2();
	public bool activ=true;
	public bool flagHit = false;

	public void killMutatedBat()
	{
		if (IsOnFloor()) vvv.y=0;//gravity
		else vvv.y+=Gravity;
		GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", true);
		GetNode<CollisionShape2D>("DeadColl").SetDeferred("disabled", false);
		activ =false;
		vvv.x=0;
		_animatedSprite.Play("Dead");
	}
	
 	public override void _Process(float delta)
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		if (activ==true)
		{
			if (IsOnWall()) speed *= (-1);
			vvv.x=speed;
		}
	 	
		if (flagHit==true) return;
		MoveAndSlide(vvv, Upp);
		//animated
		if (vvv.x > 0 && flagHit==false)
		{
			_animatedSprite.Play("Walk");//вправо
			_animatedSprite.FlipH = false;
		}
		else if (vvv.x < 0 && flagHit==false)
		{
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
			flagHit = true;
			_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
			_animatedSprite.Play("Hit");
			PlayerKinematicBody2D v = body as PlayerKinematicBody2D;
			v.Damage();
			v.Dead();
		}
		if ((body is Player02) && activ)
		{
			flagHit = true;
			_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
			_animatedSprite.Play("Hit");
			Player02 v = body as Player02;
			v.Damage();
			v.Dead();
		}
	}
}



