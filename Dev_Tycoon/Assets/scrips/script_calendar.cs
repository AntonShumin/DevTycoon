using UnityEngine;
using System.Collections;

public class script_calendar : MonoBehaviour {

    public string[] date_month = new string[12];
    public int[] date_days = new int[12];
    public float day_tick = 0.2f;
    
    //calendar vars
    private bool time_running = false;
    private int current_month = 0;
    private float current_day = 0;
    private int current_year = 1996;

    //dev weeks timer
    private float project_day_count;
    private int project_day_max = 60;
    private bool project_running = false;
    private float project_progress_segment = 25f;


	// Use this for initialization
	void Start () {
        time_running = true;
        project_running = true;
        StartCoroutine("tik_tok");
    }

    private IEnumerator tik_tok()
    {
        string date_string = "";
        string date_prefix = "";
        float project_week;
        float project_progress;
        script_upperFrame o_upperFrame = script_GameManager.Instance.o_ui.upper_frame;
        while (true)
        {
            yield return new WaitForSeconds(day_tick);
            if(time_running)
            {
                //REGULAR DAYS
                current_day += day_tick;
                if(current_day > date_days[current_month])
                {
                    current_day = 1;
                    current_month++;
                    if (current_month > 11) current_month = 0;
                }
                date_prefix = current_day < 10 ? "0" : "";
                date_string = "Y"+current_year+" "+date_month[current_month] + " " + date_prefix + Mathf.Floor(current_day);
                o_upperFrame.set_date(date_string);
               
                //PROJECT DAYS
                if(project_running)
                {
                    project_day_count += day_tick;
                    project_week = Mathf.Floor(project_day_count / 7);
                    project_progress = Mathf.Round((float)project_day_count / (float)project_day_max * 100);
                    if (project_progress > 100) project_progress = 100;
                    if(project_progress_segment <= 100)
                    {
                        if(project_progress >= project_progress_segment)
                        {

                            project_progress_segment += 25;
                        }
                    }
                    o_upperFrame.set_project_date(project_progress,project_week);
                }
            }
                                                   
        }
    }

}
