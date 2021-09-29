﻿using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Febucci.UI
{
    /// <summary>
    /// Default TextAnimatorPlayer, which can show letters dynamically (like a typewriter).<br/>
    /// To enable it, add this component near a <see cref="TextAnimator"/> one<br/>
    /// - Base class: <see cref="Core.TAnimPlayerBase"/><br/>
    /// - Manual: <see href="https://www.textanimator.febucci.com/docs/text-animator-players/">TextAnimatorPlayers</see>
    /// </summary>
    [HelpURL("https://www.textanimator.febucci.com/docs/text-animator-players/")]
    [AddComponentMenu("Febucci/TextAnimator/TextAnimatorPlayer")]
    public class TextAnimatorPlayer : Core.TAnimPlayerBase
    {
        [SerializeField] [Attributes.CharsDisplayTime] [Tooltip("Wait time for normal letters")] public float waitForNormalChars = .03f;
        [SerializeField] [Attributes.CharsDisplayTime] [Tooltip("Wait time for ! ? .")] public float waitLong = .6f;
        [SerializeField] [Attributes.CharsDisplayTime] [Tooltip("Wait time for ; : ) - ,")] public float waitMiddle = .2f;
        [SerializeField] [Tooltip("-True: only the last punctuaction on a sequence waits for its category time.\n-False: each punctuaction will wait, regardless if it's in a sequence or not")] bool avoidMultiplePunctuactionWait = false;

        [SerializeField, Tooltip("True if you want the typewriter to wait for new line characters")] bool waitForNewLines = true;

        [SerializeField, Tooltip("True if you want the typewriter to wait for all characters, false if you want to skip waiting for the last one")] bool waitForLastCharacter = true;

        [SerializeField, Tooltip("")]private bool waitingForInput = false;


        protected override float WaitTimeOf(char character)
        {
            //avoids waiting for the last character
            if (!waitForLastCharacter && textAnimator.allLettersShown)
                return 0;

            //avoids waiting for multiple times if there are puntuactions near each other
            if (avoidMultiplePunctuactionWait && char.IsPunctuation(character))
            {
                if (textAnimator.TryGetNextCharacter(out var result))
                {
                    if (char.IsPunctuation(result.character)) //next character is punctuation
                    {
                        return waitForNormalChars;
                    }
                }
            }

            //avoids waiting for new lines
            if (!waitForNewLines && !textAnimator.latestCharacterShown.isVisible)
            {
                bool IsUnicodeNewLine(ulong unicode) //Returns true if the unicode value represents a new line
                {
                    return unicode == 10 || unicode == 13;
                }

                //skips waiting for a new line
                if (IsUnicodeNewLine(textAnimator.latestCharacterShown.textElement.unicode))
                    return 0;
            }

            //character is not before another punctuaction
            switch (character)
            {
                case ';':
                case ':':
                case ')':
                case '-':
                case ',': return waitMiddle;

                case '!':
                case '?':
                case '.':
                    return waitLong;
            }

            return waitForNormalChars;
        }

        /// <summary>
        /// Waits any input from the user.
        /// </summary>
        /// <returns></returns>
        protected override IEnumerator WaitInput()
        {

            //waitingForInput = true;
            Debug.Log("This Coroutine is being called...");

            while (!Keyboard.current.anyKey.wasPressedThisFrame)
            {
                waitingForInput = true;
                yield return null;

                Debug.Log("This has ended...");

            }
        }

        /// <summary>
        /// Method that sets the value for the isWaitingForInput variable.
        /// </summary>
        /// <returns></returns>
        public void SetWaitingForInput(bool state)
        {
            waitingForInput = state;  
        }

    }
}