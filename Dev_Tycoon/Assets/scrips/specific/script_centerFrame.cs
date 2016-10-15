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
    private string[,] presets = new string[5,2];

    void Awake()
    {
        define_presets();
    }

    public void show(float progress)
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<DOTweenAnimation>().DOPlayById("show");
        int preset_index = (int)progress / 25;
        string title_new = "Project milestone " + progress + "%";
        switch ((int)progress)
        {
            case 0:
               title_new = "Begin a new Project";
                
                break;
            case 25:
                
                break;
            case 50:

                break;
            case 75:

                break;
            case 100:
                title_new = "Almost there";
                break;
            
        }
        o_title.GetComponent<Text>().text = title_new;
        o_header.GetComponent<Text>().text = presets[preset_index, 0];
        o_text.GetComponent<Text>().text = presets[preset_index, 1];
        o_icon.GetComponent<Image>().sprite = icon[preset_index];

    }

    private void define_presets()
    {
        presets[0, 0] = "GAMEPLAY DESIGN";
        presets[0, 1] = "Gameplay is the most important part of any game. Higher number will greatly influence the <color=yellow>score</color> and the <color=yellow>sales duration</color>.";
        presets[1, 0] = "GRAPHICS DESIGN";
        presets[1, 1] = "Everyone loves fancy graphics. A pretty game is bound to sell a <color=yellow>large amount</color> of units and boost the <color=yellow>awareness</color> of potential players.";
        presets[2, 0] = "SOUND DESIGN";
        presets[2, 1] = "Great sound can make an average game good, and a good game great. It's a <color=yellow>multiplier</color> of the gameplay and the visuals.";
        presets[3, 0] = "MARKETING";
        presets[3, 1] = "Time to think about marketing. This is also your last chance to improve gameplay, sound and design.";
        presets[4, 0] = "FINAL POLISH";
        presets[4, 1] = "All core parts of the game are in place. It's time to clean up the <color=yellow>bugs</color> and <color=yellow>polish</color> rough endges.";

    }

    public void close()
    {
        gameObject.GetComponent<DOTweenAnimation>().DOPlayById("hide");
    }

}
