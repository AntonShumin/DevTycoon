using UnityEngine;
using System.Collections;

public class script_calendar : MonoBehaviour {

    public string[] date_month = new string[12];
    public int[] date_days = new int[12];
    public float day_tick = 1f;
    
    //calendar vars
    private bool time_running = false;
    private int current_month = 0;
    private int current_day = 0;
    private int current_year = 1996;

    //dev weeks timer
    private 


	// Use this for initialization
	void Start () {
        time_running = true;
        StartCoroutine("tik_tok");
    }

    private IEnumerator tik_tok()
    {
        string date_string = "";
        string date_prefix = "";
        script_upperFrame o_upperFrame = script_GameManager.Instance.o_ui.upper_frame;
        while (true)
        {
            yield return new WaitForSeconds(day_tick);
            if(time_running)
            {
                current_day++;
                if(current_day > date_days[current_month])
                {
                    current_day = 1;
                    current_month++;
                    if (current_month > 11) current_month = 0;
                }
                date_prefix = current_day < 10 ? "0" : "";
                date_string = "Y"+current_year+" "+date_month[current_month] + " " + date_prefix + current_day;
                //script_GameManager.Instance.o_ui.upper_frame.set_date(date_string);
                o_upperFrame.set_date(date_string);
                Debug.Log(date_string);
            }
                                                   
        }
    }

}
