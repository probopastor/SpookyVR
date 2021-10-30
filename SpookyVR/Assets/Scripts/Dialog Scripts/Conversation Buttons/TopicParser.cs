using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicParser : MonoBehaviour
{
    [Tooltip(" ")] private DialogHandler dialogHandler;
    [Tooltip(" ")] private List<TextState> parsedTextState = new List<TextState>(); 

    // Start is called before the first frame update
    void Start()
    {
        dialogHandler = FindObjectOfType<DialogHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Determines which text state, from a list of text states, should be chosen based on certain variables.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public List<TextState> ParseInteractions(List<Interactions> interactions)
    {

        return parsedTextState;
    }

    public void StartDialog()
    {
        StartCoroutine(dialogHandler.RunDialog(parsedTextState));
    }
}
