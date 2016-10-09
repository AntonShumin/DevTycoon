using UnityEngine;
using System.Collections;
using DG.Tweening;

public class script_centerFrame : MonoBehaviour {

    public GameObject o_title;
    public GameObject o_text;
    public GameObject o_icon;

    public void show()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<DOTweenAnimation>().DOPlayById("show");
    }

}
