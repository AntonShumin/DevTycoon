using UnityEngine;
using System.Collections;

public class script_gameEvents : MonoBehaviour {

    private string[,] messages = new string[1,2];


    void Awake()
    {
        setup_messages();
    }

    void Start()
    {
        set_message(0);
    }


    public void set_message(int index)
    {
        Debug.Log(messages[0, 0]);
        script_GameManager.Instance.manager_ui.message_center.set_item(messages[index, 0], messages[index, 1]);
    }

    private void setup_messages()
    {
        messages[0,0] = "Develop your first game";
        messages[0,1] = "G";

    }

    public void project_progress(float progress)
    {
        script_GameManager.Instance.manager_gm.s_calendar.pause_calendar();
        script_GameManager.Instance.manager_ui.center_frame.show(progress);
    }

    public void project_progress_close()
    {
        script_GameManager.Instance.manager_ui.center_frame.close();
        script_GameManager.Instance.manager_gm.s_calendar.resume_calendar();
    }


}
