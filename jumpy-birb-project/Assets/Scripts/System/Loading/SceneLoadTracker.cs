using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class SceneLoadTracker : MonoBehaviour
    {
        private void Awake()
        {
            SceneLoadManager.Instance.OnLoadedGameScene(gameObject.scene.buildIndex);
        }
    }
}
