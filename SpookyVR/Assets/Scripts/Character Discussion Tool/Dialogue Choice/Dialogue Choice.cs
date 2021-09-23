using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DialogueChoice : MonoBehaviour //IPointerEnterHandler
{

    private string choiceText;
    private TextMeshProUGUI choiceTextObj;

    private void Awake()
    {
        choiceTextObj = GetComponent<TextMeshProUGUI>();
    }
    #region Start and Update
    // Start is called before the first frame update
    void Start()
    {
        choiceTextObj.text = "Hello Peasent.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
