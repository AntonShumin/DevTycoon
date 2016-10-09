using UnityEngine;
using DG.Tweening;
using System.Collections;

public class script_ui : MonoBehaviour {

    private bool lower_frame_visible = false;
    private bool lower_frame_inTransition = false;

    //lower frame
    public GameObject lower_frame;
    //upper frame
    public script_upperFrame upper_frame;
    //center frame
    public GameObject o_center_frame;
    public script_centerFrame center_frame;
    //message center
    public GameObject go_message_center;
    public script_messageCenter message_center;

    void Awake()
    {
        //Setup Game Manager reference
        script_GameManager.Instance.setup_objects(1, gameObject);
        //setup object scripts 
        message_center = go_message_center.GetComponent<script_messageCenter>();
        center_frame = o_center_frame.GetComponent<script_centerFrame>();
    }


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
