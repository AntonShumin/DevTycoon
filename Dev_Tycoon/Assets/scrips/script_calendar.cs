using UnityEngine;
using System.Collections;

public class script_calendar : MonoBehaviour {

    public string[] date_month = new string[12];
    public int[] date_days = new int[12];
    public float day_tick = 1f;
    
    private bool time_running = false;
    private int current_month = 0;
    private int current_day = 1;
    private int current_year = 1996;


	// Use this for initialization
	void Start () {
        time_running = true;
        StartCoroutine("tik_tok");
    }

    private IEnumerator tik_tok()
    {
        string date_string = "";
        script_ui o_ui = script_GameManager.Instance.o_ui;
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
                date_string = "Y"+current_year+" "+date_month[current_month]+" "+current_day;
                Debug.Log(date_string);
            }
                                                   
        }
    }

}
