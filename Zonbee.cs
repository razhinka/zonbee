using Godot;
using System;
using System.ComponentModel;

public partial class Zonbee : CharacterBody3D
{
    [Export]
    public int Speed { get; set; } = 14;
    [Export]
    public int Health { get; set; } = 10;
    private Vector3 _targetVelocity = Vector3.Zero;

    public override void _Process(double delta)
    {
        if (Input.IsActionJustReleased("spawn"))
        {
            Health -= 1;
        }
        var direction = Vector3.Zero;
        direction.X -= 1.0f;
        if (direction != Vector3.Zero)
        {
            direction = direction.Normalized();
        }
        _targetVelocity.X = direction.X * Speed;
        Velocity = _targetVelocity;
        if (Health == 0)
        {
            QueueFree();
        }
        MoveAndSlide();
    }
}
