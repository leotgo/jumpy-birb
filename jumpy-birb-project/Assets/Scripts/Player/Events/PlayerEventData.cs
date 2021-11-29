using UnityEngine;

namespace JumpBirdGame
{
    [CreateAssetMenu(fileName = "PlayerEventData", menuName = "jumpy-birb/Player/Player Event Data", order = 1)]
    public class PlayerEventData : ScriptableObject
    {
        /* ------------------------------- Properties ------------------------------- */

        public ScriptableEvent OnJump
        {
            get => _onJump;
        }

        public ScriptableEvent OnHitObstacle
        {
            get => _onHitObstacle;
        }

        public ScriptableEvent OnHitGround
        {
            get => _onHitGround;
        }

        public ScriptableEvent OnScore
        {
            get => _onScore;
        }

        public ScriptableEvent OnDeath
        {
            get => _onDeath;
        }

        public ScriptableEvent OnSpawn
        {
            get => _onSpawn;
        }

        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private ScriptableEvent _onJump;
        [SerializeField] private ScriptableEvent _onScore;
        [SerializeField] private ScriptableEvent _onHitObstacle;
        [SerializeField] private ScriptableEvent _onHitGround;
        [SerializeField] private ScriptableEvent _onDeath;
        [SerializeField] private ScriptableEvent _onSpawn;

        /* -------------------------------------------------------------------------- */
    }
}