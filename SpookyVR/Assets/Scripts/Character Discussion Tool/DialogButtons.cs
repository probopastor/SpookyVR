using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogButtons : MonoBehaviour
{
    [Tooltip(" ")] private int textStateID = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sets the ID of the main dialog text state when this text option is selected. For example, if talking about pineapples, the ID corresponding to the pineapple conversation may be 5. 
    /// </summary>
    /// <param name="mainDialogTextStateID"></param>
    public void SetDialogTopic(int mainDialogTextStateID)
    {
        textStateID = mainDialogTextStateID;
    }

    public void SetDialogMusic(AudioClip musicClip)
    {

    }
}
