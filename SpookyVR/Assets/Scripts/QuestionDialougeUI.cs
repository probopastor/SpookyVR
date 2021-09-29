using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public abstract class QuestionDialougeUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI questionText;
    [SerializeField]
    private string questionString;

    [SerializeField]
    private Button yesBtn;
    [SerializeField]
    private Button noBtn;

    private Action yesAction;
    private Action noAction;


    #region Getters and Setters

    #region Getters
    public TextMeshProUGUI GetTMPText()
    {
        return questionText;
    }

    public string GetQuestionString()
    {
        return questionString;
    }

    /// <summary>
    /// Enter the name of the button you wish to have access and this method will return it.
    /// </summary>
    /// <param name="buttonName"></param>
    /// <returns></returns>
    public Button GetButton(string buttonName)
    {
        Button buttonToReturn = null;

        if(buttonName == yesBtn.name)
        {
            buttonToReturn = yesBtn;
            return buttonToReturn;
        }
        else if(buttonName == noBtn.name)
        {
            buttonToReturn = noBtn;
            return buttonToReturn;
        }

        return buttonToReturn;
    }
    #endregion

    #region Setters



    #endregion

    #endregion



    public virtual void Awake()
    {
        InitializeVariables();
    }

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        
    }

    public abstract void InitializeVariables();
    //{
    //    questionText = transform.Find("DialogueText").GetComponent<TextMeshProUGUI>();
    //    yesBtn = transform.Find("YesBtn").GetComponent<Button>();
    //    noBtn = transform.Find("NoBtn").GetComponent<Button>();
    //}

    private void EstablishActionListeners()
    {
        
    }
}
