using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;
 
 
 
 
public class timelineMarker : MonoBehaviour
 
{
    // This is to assign ANOTHER timeline (not just to one on this Game Object)
    // b/c This game object is a trigger - someting you mouse up or gaze @ -
    //  that will take you to a specific "Marker"
    // NOTE: the Marker # is not necessarily sequential... Marker # may have to do with the order in which they are created
    public PlayableDirector playableDirector;
    // The # of the Marker you want to go to
    public int markerNum;
 
    void Start()
    {
       playableDirector = GetComponent<PlayableDirector>();
    }
 
    void OnMouseUp()
    {
           
            var timelineAsset = playableDirector.playableAsset as TimelineAsset;
            var markers = timelineAsset.markerTrack.GetMarkers().OrderBy((marker) => marker.time).ToArray();
            playableDirector.Play();
            playableDirector.time = markers[markerNum].time;
           
    }
}
 