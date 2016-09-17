using UnityEngine;
using DG.Tweening;
using System.Collections;

public class script_ui : MonoBehaviour {

    private bool lower_frame_visible = false;
    private bool lower_frame_inTransition = false;
    public GameObject lower_frame;

	public void lower_frame_toggle()
    {
        if(!lower_frame_inTransition)
        {
            string animate_string = lower_frame_visible ? "hide" : "show";
            lower_frame_visible = !lower_frame_visible;
            lower_frame.GetComponent<DOTweenAnimation>().DOPlayById(animate_string);
            lower_frame_transition(true);
        }
        
    }

    public void lower_frame_transition(bool transition)
    {
        lower_frame_inTransition = transition;
    }
}
