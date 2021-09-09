using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBank : MonoBehaviour
{
    #region Otlo Overall Resources
    [Tooltip(" ")] private int population = 0;
    [Tooltip(" ")] private int money = 0;
    [Tooltip(" ")] private int food = 0;
    [Tooltip(" ")] private int militia = 0;
    [Tooltip(" ")] private int crimeRate = 0;
    [Tooltip(" ")] private int cultPresence = 0;
    #endregion

    #region Location Resources

    #region 1. Village Center Resources

    [Tooltip(" ")] private int prosperity_VillageCenter = 0;
    [Tooltip(" ")] private int moneyProduced_VillageCenter = 0;
    [Tooltip(" ")] private bool militiaStationed_VillageCenter = false;

    #endregion

    #region 2. Central Bank Resources

    [Tooltip(" ")] private int prosperity_CentralBank = 0;
    [Tooltip(" ")] private bool militiaStationed_CentralBank = false;

    #endregion

    #region 3. The Fields Resources

    [Tooltip(" ")] private int prosperity_TheFields = 0;
    [Tooltip(" ")] protected int foodProduced_TheFields = 0;
    [Tooltip(" ")] private bool militiaStationed_TheFields = false;

    #endregion

    #region 4. The Barracks Resources

    [Tooltip(" ")] private int prosperity_TheBarracks = 0;
    [Tooltip(" ")] private bool militiaStationed_TheBarracks = false;

    #endregion

    #region 5. The Church Resources

    [Tooltip(" ")] private int prosperity_TheChurch = 0;
    [Tooltip(" ")] private bool militiaStationed_TheChurch = false;

    #endregion

    #region 6. The Slums Resources

    [Tooltip(" ")] private int prosperity_TheSlums = 0;
    [Tooltip(" ")] private int crimeProduced_TheSlums = 0;
    [Tooltip(" ")] private bool militiaStationed_TheSlums = false;

    #endregion

    #region 7. Lucky's Tavern Resources

    [Tooltip(" ")] private int prosperity_LuckysTavern = 0;
    [Tooltip(" ")] private int moneyProduced_LuckysTavern = 0;
    [Tooltip(" ")] private bool militiaStationed_LuckysTavern = false;

    #endregion

    #endregion

    #region Character Resources

    #region 1. Richy Resources

    [Tooltip(" ")] private int trust_Richy = 0;
    [Tooltip(" ")] private bool isDead_Richy = false;

    #endregion

    #region 2. Esfir

    [Tooltip(" ")] private int trust_Esfir = 0;
    [Tooltip(" ")] private bool isDead_Esfir = false;

    #endregion

    #region 3. Dmitri

    [Tooltip(" ")] private int trust_Dmitri = 0;
    [Tooltip(" ")] private bool isDead_Dmitri = false;

    #endregion

    #region 4. Rigor

    [Tooltip(" ")] private int trust_Rigor = 0;
    [Tooltip(" ")] private bool isDead_Rigor = false;

    #endregion

    #region 5. Petrov

    [Tooltip(" ")] private int trust_Petrov = 0;
    [Tooltip(" ")] private bool isDead_Petrov = false;

    #endregion

    #region 6. Sacha Resources

    [Tooltip(" ")] private int trust_Sacha = 0;
    [Tooltip(" ")] private bool isDead_Sacha = false;

    #endregion

    #region 7. Lucky Resources

    [Tooltip(" ")] private int trust_Lucky = 0;
    [Tooltip(" ")] private bool isDead_Lucky = false;

    #endregion 

    #region 8. Bishop Pryce Resources

    [Tooltip(" ")] private int trust_BishopPryce = 0;
    [Tooltip(" ")] private bool isDead_BishopPryce = false;

    #endregion 

    #region 9. Natalia Resources

    [Tooltip(" ")] private int trust_Natalia = 0;
    [Tooltip(" ")] private bool isDead_Natalia = false;

    #endregion 

    #region 8. Molotov Resources

    [Tooltip(" ")] private int trust_Molotov = 0;
    [Tooltip(" ")] private bool isDead_Molotov = false;

    #endregion 

    #endregion


    public static ResourceBank _resourceBank;

    private void Awake()
    {
        if (_resourceBank != null && _resourceBank != this)
        {
            Destroy(_resourceBank.gameObject);
        }
        else
        {
            _resourceBank = this;
            DontDestroyOnLoad(_resourceBank.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region 1. Village Center Methods

    #region Getters

    #endregion

    #region Setters

    #endregion 

    #endregion

    #region 2. Central Bank Methods

    #endregion

    #region 3. The Fields Methods 

    #endregion

    #region 4. The Barracks Methods

    #endregion

    #region 5. The Church Methods

    #endregion

    #region 6. The Slums Methods

    #endregion

    #region 7. Lucky's Tavern Methods

    #endregion
}
