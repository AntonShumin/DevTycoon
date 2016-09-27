using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using EnhancedUI.EnhancedScroller;

public class script_scroller_view : EnhancedScrollerCellView {

    public Text itemNameText;

    public void SetData(scriipt_scroller_model model)
    {
        itemNameText.text = model.name;
    }
    	
}
