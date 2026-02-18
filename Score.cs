using Godot;
using System;

public partial class Score : Node
{
    [Export]
    public int CurrentScore { get; set; } = 0;

    public int MaxMultiplier = 0;

    public void OnMobSquashed(int multiplier = 1)
    {
        if (multiplier > MaxMultiplier)
        {
            MaxMultiplier = multiplier;
        }
        CurrentScore += multiplier;
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
