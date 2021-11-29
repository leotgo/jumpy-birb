using UnityEngine;

namespace JumpBirdGame
{
    public class SceneLoadSignalizer : MonoBehaviour
    {
        /* ------------------------ Inspector-Assigned Fields ----------------------- */

        [SerializeField] private ScriptableEvent _sceneLoadEvent;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Awake()
        {
            SceneLoadManager.Instance.Raise(_sceneLoadEvent);
        }

        /* -------------------------------------------------------------------------- */
    }
}