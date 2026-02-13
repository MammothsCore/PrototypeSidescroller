using UnityEngine;

public class PatrolState : State
{
    public PatrolState(Enemy enemy) : base(enemy) { }  

    public override void FixedUpdate()
    {
        if(senses.IsHittingWall() || senses.IsAtCliff())
            { 
            return; 
            }
        rb.linearVelocity = new Vector2(config.patrolSpeed, rb.linearVelocity.y);
    }
}
