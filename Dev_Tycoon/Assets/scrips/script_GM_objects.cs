using UnityEngine;
using System.Collections;

public class script_GM_objects : MonoBehaviour {

    //calendar
    public GameObject go_calendar;
    public script_calendar s_calendar;
    //game events
    public GameObject go_events;
    public script_gameEvents events;
    //input
    public GameObject go_input;
    public script_input input;

    void Awake()
    {
        s_calendar = go_calendar.GetComponent<script_calendar>();
        events = go_events.GetComponent<script_gameEvents>();
        script_GameManager.Instance.setup_objects(0,gameObject);
    }


}
