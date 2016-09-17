using UnityEngine;
using System.Collections;

public class script_orbit : MonoBehaviour {

    //FIELDS
    public GameObject target = null;
    //auto rotation
    public int rotation_speed = 15;
    public bool auto_orbit = false;
    //drag rotation
    public int drag_speed = 300;
    public float drag_value = 0;
    public float drag_decay = 0;
    public bool mouse_pressed = false;

	
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
                //float rotX = Input.GetAxis("Mouse X") * drag_speed * Mathf.Deg2Rad;
                float rotation_y = Camera.main.transform.rotation.eulerAngles.y;
                float rotation_y_adjusted = rotation_y;            

                float input_X = Input.GetAxis("Mouse X") * drag_speed * Time.deltaTime;
                drag_value += input_X;
                Debug.Log(drag_value);
                float input_Y = Input.GetAxis("Mouse Y") * drag_speed * Time.deltaTime / 2;
                Camera.main.transform.RotateAround(target.transform.position, Vector3.up, input_X);
                Camera.main.transform.RotateAround(target.transform.position, Camera.main.transform.right, -1*input_Y);


            }
        }

	}

}
