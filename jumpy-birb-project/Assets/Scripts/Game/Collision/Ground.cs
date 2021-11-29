using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class Ground : MonoBehaviour, IHitboxOwner
    {
        /* ------------------------------- Game Events ------------------------------ */

        public void OnHitboxCollision(IPhysicsEntity2D entity)
        {
            if (entity is Player)
            {
                var player = entity as Player;
                player.HitGround();
            }
        }

        /* -------------------------------------------------------------------------- */
    }
}
