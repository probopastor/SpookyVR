using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopicParser : MonoBehaviour
{
    [SerializeField, Tooltip("An array of trust brackets. Determines which parsed TextState should be returned. Inclusive. ")] private int[] trustBrackets;

    /// <summary>
    /// Determines which text state, from a list of text states, should be chosen based on certain variables.
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public List<TextState> ParseInteractions(List<Interactions> interactions, Character character)
    {
        // The parsed text
        List<TextState> parsedText = new List<TextState>();

        // The character's trust
        int characterTrust = character.GetTrust();

        // The current trustBracket the character is in. 5 in total
        int trustBracket = 0;

        // Cycle through the trust brackets
        for (int i = 0; i < trustBrackets.Length; i++)
        {
            // Ensure that the comparison does not compare to an element outside the bounds of the array
            if (i > 0)
            {
                // If the character trust is not between the lower bracket bound and the higher bracket bound
                if (!(characterTrust > trustBrackets[i - 1]) && !(characterTrust < trustBrackets[i]))
                {
                    // Then the trust does not fall into this bracket, so increase the trustBracket count.
                    trustBracket++;
                }
            }
        }

        // Choose the text state that correlates to the trustBracket
        parsedText = interactions[trustBracket].GetTextStates();

        // Returns this text state
        return parsedText;
    }

    public void SubmitDialog(List<TextState> parsedTopic, DialogHandler handler)
    {
        StartCoroutine(handler.RunDialog(parsedTopic));
    }

}
