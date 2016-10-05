using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class script_upperFrame : MonoBehaviour {

    public GameObject o_date;
	private Text text_date;

    public GameObject o_week;
    private Text text_week;

    public GameObject o_progress;
    private Text text_progress;

    void Awake()
    {
        text_date = o_date.GetComponent<Text>();
        text_week = o_week.GetComponent<Text>();
        text_progress = o_progress.GetComponent<Text>();
    }

    public void set_date(string para1)
    {
        text_date.text = para1;
    }

    public void set_project_date(float project_progress, float project_week)
    {
        text_week.text = project_progress + "%";
        text_progress.text = "W" + project_week;
    }
}
