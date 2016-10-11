using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class script_centerFrame : MonoBehaviour {

    //elements
    public GameObject o_title;
    public GameObject o_header;
    public GameObject o_text;
    public GameObject o_icon;

    public Sprite[] icon  = new Sprite[4];

    //presets
    private string[,] presets = new string[1, 2];

    void Awake()
    {
        define_presets();
    }

    public void show(float progress)
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<DOTweenAnimation>().DOPlayById("show");

    }

    private void define_presets()
    {
        presets[0, 0] = "GAMEPLAY DESIGN";
        presets[0, 1] = "Gameplay is the most important part of any game. Higher number will greatly influence the <color=yellow>score</color> and the <color=yellow>sales duration</color>.";
    }

}
