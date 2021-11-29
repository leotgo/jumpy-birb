using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "GameVisualStyle", menuName = "jumpy-birb/Game/Visual Style Data", order = 1)]
    public class VisualStyleData : ScriptableObject
    {
        public PlayerSpriteAnimation[] PlayerSpriteAnims
        {
            get => _playerSpriteAnimations;
        }

        [SerializeField] private PlayerSpriteAnimation[] _playerSpriteAnimations;
        [SerializeField] private Sprite[] _backgroundSprites;
        [SerializeField] private Sprite[] _pipeSprites;

        public Sprite GetBackgroundSprite(TimeOfDay time)
        {
            return _backgroundSprites[(int) time];
        }

        public Sprite GetPipeSprite(TimeOfDay time)
        {
            return _pipeSprites[(int)time];
        }

        public PlayerSpriteAnimation GetRandomPlayerSpriteAnim()
        {
            return _playerSpriteAnimations[Random.Range(0, _playerSpriteAnimations.Length)];
        }
    }
}