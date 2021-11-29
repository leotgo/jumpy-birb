using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JumpBirdGame
{
    public class MainMenuUIDirector : MonoBehaviour
    {
        /* ------------------------------- Game Events ------------------------------ */

        public void OnClickStartGameButton()
        {
            UIManager.Instance.StartGame();
        }

        public void OnClickExitGameButton()
        {
            UIManager.Instance.ExitGame();
        }

        /* -------------------------------------------------------------------------- */
    }
}
