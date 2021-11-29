using UnityEngine;

namespace JumpBirdGame
{
    public enum TimeOfDay
    {
        Day = 0,
        Night = 1,
    }

    public enum PlayerSpriteColor
    {
        YellowBird = 0,
        RedBird = 1,
        BlueBird = 2,
    }

    [System.Serializable]
    public struct SpriteColorAnimation
    {
        public PlayerSpriteColor SpriteColor
        {
            get => _color;
        }

        public PlayerSpriteAnimation AnimationAsset
        {
            get => _animationAsset;
        }

        [SerializeField] private PlayerSpriteColor _color;
        [SerializeField] private PlayerSpriteAnimation _animationAsset;
    }
}