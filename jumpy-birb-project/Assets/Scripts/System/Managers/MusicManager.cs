using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    /* ------------------------ Inspector-Assigned Fields ----------------------- */

    [SerializeField] private AudioSource _source;

    /* ----------------------------- Runtime Fields ----------------------------- */

    private bool _isPlaying;

    /* ------------------------------ Unity Events ------------------------------ */

    private void Awake()
    {
        _isPlaying = false;
    }

    /* -------------------------- Game Event Callbacks -------------------------- */

    public void TryStartGameMusic()
    {
        if(_isPlaying)
            return;

        _source.Play();

        _isPlaying = true;
    }

    /* -------------------------------------------------------------------------- */
}
