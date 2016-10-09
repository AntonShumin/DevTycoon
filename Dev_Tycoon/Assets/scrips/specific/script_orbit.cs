using UnityEngine;
using System.Collections;

public class script_orbit : MonoBehaviour {

    //FIELDS

    //camera rotation target
    public GameObject target = null;
    //auto rotation
    public int rotation_speed = 15;
    public bool auto_orbit = false;
    //drag rotation
    public int drag_speed = 300;
    private float drag_value_x = 0;
    private float drag_value_y = 0;
    public float drag_decay = 0.1F;
    public bool mouse_pressed = false;
    public float drag_limit = 0.6f;

    void Awake()
    {
        Debug.Log("orbit no fps limit");
        /*
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 40;
        */
    }

    // Update is called once per frame
    void Update () {
	
        if(target != null)
        {
            //Camera.main.transform.LookAt(target.transform);

            if(auto_orbit)
            {
                Camera.main.transform.RotateAround(target.transform.position, Vector3.up, Time.deltaTime * rotation_speed);
            }

            if(Input.GetMouseButtonDown(0))
            {
                mouse_pressed = true;
                auto_orbit = false;
            }

            if (Input.GetMouseButtonUp(0))
            {
                mouse_pressed = false;
            }

            if (mouse_pressed)
            {
                setDragX(Input.GetAxis("Mouse X"));
                setDragY(Input.GetAxis("Mouse Y"));
            }

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //Debug.Log(Screen.height);
                //Debug.Log(Input.GetTouch(0).deltaPosition.magnitude);
                setDragX(Input.GetTouch(0).deltaPosition.x /15);
                setDragY(Input.GetTouch(0).deltaPosition.y /15);
            }

            if(Mathf.Abs(drag_value_x) > 0 || Mathf.Abs(drag_value_y) > 0)
            {
                if (Mathf.Abs(drag_value_x) > 0)
                {
                    drag_value_x = calculateDecay(drag_value_x);
                    Camera.main.transform.RotateAround(target.transform.position, Vector3.up, drag_value_x * Time.deltaTime * drag_speed);
                }
                if (Mathf.Abs(drag_value_y) > 0)
                {
                    drag_value_y = calculateDecay(drag_value_y);
                    //get camera angle x
                    float camera_angle_x = Camera.main.transform.rotation.eulerAngles.x;
                    if (camera_angle_x > 180) camera_angle_x -= 360;
                    //limit safety net
                    float angle_upper_limit = 40;
                    float angle_lower_limit = -10;
                    float angle_limit_range = (angle_upper_limit - angle_lower_limit);
                    if (camera_angle_x > angle_upper_limit) camera_angle_x = angle_upper_limit;
                    if (camera_angle_x < angle_lower_limit) camera_angle_x = angle_lower_limit;
                    //calculate downwards movement factor
                    float drag_y_demping = 1;
                    drag_y_demping = drag_value_y < 0 ? Mathf.Abs( (angle_lower_limit - camera_angle_x)/angle_limit_range) : Mathf.Abs( (angle_upper_limit - camera_angle_x)/angle_limit_range );
                    //move camera
                    Camera.main.transform.RotateAround(target.transform.position, Camera.main.transform.right, drag_value_y * Time.deltaTime * drag_speed * drag_y_demping);
                    //reset drag if at limit
                    if (drag_y_demping == 0) drag_value_y = 0;  
                }
            }
        }

	}

    private float calculateDecay(float drag_value)
    {
        if (!mouse_pressed)
        {
            float drag_frame = drag_value * 2f * Time.deltaTime;
            drag_value -= drag_frame;
            if (Mathf.Abs(drag_value) < 0.0005f)
            {
                drag_value = 0;
            }
        }
        return drag_value;
    }

    private void setDragX(float strength)
    {
        float input_X = strength * Time.deltaTime;
        if (Mathf.Abs(drag_value_x) < drag_limit || Mathf.Sign(strength) != Mathf.Sign(drag_value_x)) drag_value_x += input_X;
    }

    private void setDragY(float strength)
    {
        float input_Y = strength * Time.deltaTime * -1;
        if (Mathf.Abs(drag_value_y) < drag_limit || Mathf.Sign(strength) != Mathf.Sign(drag_value_y)) drag_value_y += input_Y;
    }

}
