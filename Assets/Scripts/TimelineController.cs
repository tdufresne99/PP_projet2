using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    [SerializeField] private PlayableDirector _playableDirector;

    public void PauseTimeline()
    {
        _playableDirector.Pause();
    }

    public void ResumeTimeline()
    {
        _playableDirector.Resume();
    }
}

