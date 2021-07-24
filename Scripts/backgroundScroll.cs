using Godot;
using System;

public class backgroundScroll : Sprite
{
    private const float VELOCITY = -4f;
    private float g_texture_width = 0;
    public override void _Ready()
    {
        g_texture_width = Texture.GetSize().x * Scale.x;
    }

//  Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
       //MoveLocalX(VELOCITY * delta, false);
       Position += new Vector2(VELOCITY, 0);
       _Reposition();
    }

    public void _Reposition()
    {
        if (Position.x < -g_texture_width)
        {
            Position += new Vector2(2 * g_texture_width, 0);
        }
    }
}
