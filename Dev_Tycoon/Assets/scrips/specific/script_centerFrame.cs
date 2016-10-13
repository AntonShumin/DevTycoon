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
    private string[,] presets = new string[4,2];

    void Awake()
    {
        define_presets();
    }

    public void show(float progress)
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<DOTweenAnimation>().DOPlayById("show");
        switch ((int)progress)
        {
            case 2:
                o_title.GetComponent<Text>().text = "Project milestone " + progress + "%";
                o_header.GetComponent<Text>().text = presets[0, 0];
                o_text.GetComponent<Text>().text = presets[0, 1];
                o_icon.GetComponent<Image>().sprite = icon[0];
                break;
            case 27:
                o_title.GetComponent<Text>().text = "Project milestone " + progress + "%";
                o_header.GetComponent<Text>().text = presets[1, 0];
                o_text.GetComponent<Text>().text = presets[1, 1];
                o_icon.GetComponent<Image>().sprite = icon[1];
                break;
        }

    }

    private void define_presets()
    {
        presets[0, 0] = "GAMEPLAY DESIGN";
        presets[0, 1] = "Gameplay is the most important part of any game. Higher number will greatly influence the <color=yellow>score</color> and the <color=yellow>sales duration</color>.";
        presets[1, 0] = "GRAPHICS DESIGN";
        presets[1, 1] = "Everyone loves fancy graphics. A pretty game is bound to sell a <color=yellow>large amount</color> of units and boost the <color=yellow>awareness</color> of potential players.";
        presets[2, 0] = "SOUND DESIGN";
        presets[2, 1] = "Great sound can make an average game good, and a good game great. It's a <color=yellow>multiplier</color> of the gameplay and the visuals.";
        presets[3, 0] = "POLISH";
        presets[3, 1] = "All core parts of the game are in place. It's time to clean up the bugs and make it presentable.";

    }

    public void close()
    {
        gameObject.GetComponent<DOTweenAnimation>().DOPlayById("hide");
    }

}
