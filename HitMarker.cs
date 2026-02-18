using Godot;
using System;

public partial class HitMarker : Node3D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void Initialize(Vector3 position, int multiplier)
    {
        Position = position;
        GetNode<Label3D>("ScoreDisplay").Text = multiplier.ToString();
    }

    private void OnHitMarkerTimerTimeout()
    {
        QueueFree();
    }
}
