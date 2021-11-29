using System.Runtime.CompilerServices;
using System;
using System.Globalization;
using UnityEngine;

namespace JumpBirdGame
{
    public class PlayerInputHandler : MonoBehaviour
    {
        /* ------------------------- Runtime-Assigned Fields ------------------------ */

        [SerializeField] private Player _player;

        /* ------------------------------ Unity Events ------------------------------ */

        private void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {
                _player.Jump();
            }
            if(Input.GetButtonDown("Pause"))
            {
                UIManager.Instance.TogglePause();
            }
        }

        /* -------------------------------------------------------------------------- */
    }
}