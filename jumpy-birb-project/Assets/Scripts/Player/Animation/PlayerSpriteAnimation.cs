using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "PlayerAnimationData", menuName = "jumpy-birb/Player/Player Sprite Animation", order = 1)]
    public class PlayerSpriteAnimation : ScriptableObject
    {
        /* ------------------------------- Properties ------------------------------- */

        public int Count
        {
            get => _sprites.Count;
        }

        public Sprite this[int i]
        {
            get => _sprites[i];
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private List<Sprite> _sprites;

        /* -------------------------------------------------------------------------- */
    }
}