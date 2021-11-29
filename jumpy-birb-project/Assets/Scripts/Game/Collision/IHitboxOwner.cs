using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public interface IHitboxOwner
    {
        void OnHitboxCollision(IPhysicsEntity2D entity);
    }
}
