using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public interface IPhysicsEntity2D
    {
        Vector2 Velocity { get; }
        Rigidbody2D RigidBody2D { get; }
    }
}
