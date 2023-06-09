using Godot;
using System;

public class PlayerKinematicBody2D : KinematicBody2D
{
	private AnimatedSprite _animatedSprite;

	public override void _Ready()
	{
		var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer2");
			m.Stream =GD.Load<AudioStream>("res://звуки/Action 5 (Loop).wav");
			m.Play();
	}
	
	public float speed =200;
	public int JumpImpulse = 350;
	public int Gravity = 7; //5
	public Vector2 Up = new Vector2(0, -1);
	public Vector2 vector = new Vector2();
	private PackedScene _hit = (PackedScene)GD.Load("res://hiiit.tscn");
	private PackedScene _ability = (PackedScene)GD.Load("res://ability.tscn");
	public bool flagHit=false;
	public bool flagAbility=false;
	public bool flagDead=false;
	public bool flagDead2=false;
	public static bool flagBox=false;
	
	public static int health = 300;
	public static int coin = 0;
	public static int crystal = 0;
	public static int ruby = 0;
	
	private float _abilityReloadTime = 10.0f;
	public static float _currentAbilityReloadTime = 0.0f;
	
	public float ddTime = 0.0f;
	public float flagTime = 0.0f;
	
	public void Damage()=>health-=100;
	
	public void MinusHP()=>health-=300;
	
	public void PlusHP()
	{
		if (health <300) 
		{
			health+=100;
			var n = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
			n.Stream =GD.Load<AudioStream>("res://звуки/5e9cc940c9e1cc1 (online-audio-converter.com).wav");
			n.Play();//запуск звукового эффекта
		}
	}
	
	public void PlusCoin()
	{
		coin+=1;
		var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		m.Stream =GD.Load<AudioStream>("res://звуки/coin.wav");
		m.Play();//запуск звукового эффекта
	}
	
	public void PlusRuby()
	{
		ruby+=1;
		var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		m.Stream =GD.Load<AudioStream>("res://звуки/gem.wav");
		m.Play();//запуск звукового эффекта
	}
	
	public void KeyMus()
	{
		var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		m.Stream =GD.Load<AudioStream>("res://звуки/keymus.wav");
		m.Play();//запуск звукового эффекта
	}
	
	public void PlusCrystal()
	{
		crystal+=1;
		flagBox=true;
	}
	
	public void Reset()
	{
		crystal=0;
		ruby=0;
		coin=0;
		health=300;
		Restart.flag=false;
		GameOver.flag=false;
		BoxL01.flag=false;
	}
	
	private void UseAbility() 
	{
		if (_currentAbilityReloadTime <= 0.0f) 
			_currentAbilityReloadTime = _abilityReloadTime;
	}
	
	public void Transition()=>flagTime=4.0f;
	
	public void Dead()
	{
		if (health<=0&&health>-500)
		{
			if (IsOnFloor()) vector.y=0;//gravity
			else vector.y+=150;
			_animatedSprite.Play("Dead");
			flagDead=true;
			
			var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
			m.Stream =GD.Load<AudioStream>("res://звуки/gameovermus.wav");
			m.Play();
			
			ddTime=3.0f;
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		if (ddTime > 0.0f)
		{
			ddTime -= delta;
			if (ddTime <= 0.0f) 
			{
				GetTree().ChangeScene("res://Gameover/GameOver.tscn");
				Reset();
			}
		}
		if (flagTime > 0.0f)
		{
			flagTime -= delta;
			if (flagTime <= 0.0f) Flag.flagF=true;
		}
		
		if (Restart.flag) Reset();
		if (GameOver.flag) Reset();
		if (Position.y > 3000)
		{
			MinusHP();
			Dead();
		}
		
		if (flagDead) return;
		if (flagHit==true) return;
		if (flagAbility==true) return;
		
		if (_currentAbilityReloadTime > 0.0f)
			_currentAbilityReloadTime -= delta;
		
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");

		Gravitt();

		Control();

		MoveAndSlide(vector, Up);

		Animated();
	}
	
	private void _on_AnimatedSprite_animation_finished()
	{
		if (_animatedSprite.Animation=="Hit")
			flagHit = false;
		if (_animatedSprite.Animation=="Ability")
			flagAbility = false;
	}
	
	private void Gravitt()
	{
		if (IsOnFloor()) vector.y = 0;//gravity
		else if (IsOnCeiling()) vector.y = 1;
		else vector.y += Gravity;//gravity
	}

	private void Animated()
	{
		if (vector.y < 0) _animatedSprite.Play("Up");
		else if (vector.x > 0)
		{
			_animatedSprite.Play("Runn");//вправо
			_animatedSprite.FlipH = false;
		}
		else if (vector.x < 0)
		{
			_animatedSprite.Play("Runn");//влево
			_animatedSprite.FlipH = true;
		}
		else if (Input.IsActionJustPressed("hit")&&flagHit==false)
		{
			var m = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
			m.Stream =GD.Load<AudioStream>("res://звуки/attack_knight.wav");
			m.Play();
			flagHit=true;
			_animatedSprite.Play("Hit");
			Node hit = _hit.Instance();
			AddChild(hit);
		}
		else if (Input.IsActionJustPressed("ability")&&flagAbility==false)
		{
			if (_currentAbilityReloadTime <= 0.0f)
			{
				UseAbility();
				flagAbility=true;
				_animatedSprite.Play("Ability");
				Node ability = _ability.Instance();
				AddChild(ability);
			}
		}
		else _animatedSprite.Play("Stop");
	}

	private void Control()
	{
		if (Input.IsActionPressed("up") && IsOnFloor())
		{
			vector.y = -JumpImpulse;
			var mu = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
			mu.Stream =GD.Load<AudioStream>("res://звуки/jump_knight.wav");
			mu.Play();
		}
		else if (Input.IsActionPressed("left") && !(Input.IsActionPressed("right")))
			vector.x = -speed;
		else if (Input.IsActionPressed("right") && !(Input.IsActionPressed("left")))
			vector.x = +speed;
		else vector.x = 0;
	}
}




