using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationDisplayHandler : MonoBehaviour
{
    [Tooltip(" ")] private DialogHandler dialogHandler;

    // Start is called before the first frame update
    void Start()
    {
        dialogHandler = FindObjectOfType<DialogHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!dialogHandler.GetRunDialogInProgress())
        {

        }
    }
}
