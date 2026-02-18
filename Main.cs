using Godot;
using System;

public partial class Main : Node
{
    [Export]
    public PackedScene MobScene { get; set; }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<Control>("UserInterface/Retry").Hide();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    private void OnMobTimerTimeout()
    {
        Mob mob = MobScene.Instantiate<Mob>();

        var mobSpawnLocation = GetNode<PathFollow3D>("SpawnPath/SpawnLocation");

        mobSpawnLocation.ProgressRatio = GD.Randf();

        Vector3 playerPosition = GetNode<Player>("Player").Position;
        mob.Initialize(mobSpawnLocation.Position, playerPosition);

        AddChild(mob);

        mob.Squashed += GetNode<Score>("Score").OnMobSquashed;
    }

    private void OnPlayerHit()
    {
        GetNode<Timer>("MobTimer").Stop();
        int score = GetNode<Score>("Score").CurrentScore;
        GetNode<Label>("UserInterface/Retry/RetryLabel").Text = $"Final score: {score}\nPress Enter to Retry";
        GetNode<Label>("UserInterface/ScoreLabel").Hide();
        GetNode<Control>("UserInterface/Retry").Show();
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("ui_accept") && GetNode<Control>("UserInterface/Retry").Visible)
        {
            GetTree().ReloadCurrentScene();
        }
    }
}
