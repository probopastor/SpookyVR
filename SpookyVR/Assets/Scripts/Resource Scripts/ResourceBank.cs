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

    #region Resource Limiters
    [SerializeField, Tooltip(" ")] private int maxProsperity = 15;
    [SerializeField, Tooltip(" ")] private int maxTrust = 15;

    #endregion 

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

    #region Update Overall Resource Methods

    /// <summary>
    /// Updates population.
    /// </summary>
    /// <param name="changeInPop">The change in population. </param>
    public void UpdatePopulation(int changeInPop)
    {
        population += changeInPop;
    }

    /// <summary>
    /// Updates money.
    /// </summary>
    /// <param name="changeInPop">The change in money. </param>
    public void UpdateMoney(int changeInMoney)
    {
        money += changeInMoney;
    }

    /// <summary>
    /// Updates food.
    /// </summary>
    /// <param name="changeInPop">The change in food. </param>
    public void UpdateFood(int changeInFood)
    {
        food += changeInFood;
    }

    /// <summary>
    /// Updates militia.
    /// </summary>
    /// <param name="changeInPop">The change in militia. </param>
    public void UpdateMilitia(int changeInMilitia)
    {
        militia += changeInMilitia;
    }

    /// <summary>
    /// Updates crime.
    /// </summary>
    /// <param name="changeInPop">The change in crime. </param>
    public void UpdateCrime(int changeInCrime)
    {
        crimeRate += changeInCrime;
    }

    /// <summary>
    /// Updates cult presence.
    /// </summary>
    /// <param name="changeInPop">The change in cult presence. </param>
    public void UpdateCultPresence(int changeInCultPresence)
    {
        cultPresence += changeInCultPresence;
    }

    /// <summary>
    /// Updates all core resources to Otlo.
    /// </summary>
    /// <param name="changeInPop">The change in population. </param>
    /// <param name="changeInMoney">The change in money. </param>
    /// <param name="changeInFood">The change in food. </param>
    /// <param name="changeInMilitia">The change in militia. </param>
    /// <param name="changeInCrime">The change in crime. </param>
    /// <param name="changeInCult">The change in cult presence. </param>
    public void UpdateLocationResources(int changeInPop, int changeInMoney, int changeInFood, int changeInMilitia, int changeInCrime, int changeInCult)
    {
        population += changeInPop;
        money += changeInMoney;
        food += changeInFood;
        militia += changeInMilitia;
        crimeRate += changeInCrime;
        cultPresence += changeInCult;
    }

    #endregion

    #region Update Character Resource Methods

    /// <summary>
    /// Updates a character's trust.
    /// </summary>
    /// <param name="characterID">The ID of the character that should have trust updated. 
    /// 1 is Richy.
    /// 2 is Esfir.
    /// 3 is Dmitri.
    /// 4 is Rigor.
    /// 5 is Petrov.
    /// 6 is Sacha.
    /// 7 is Lucky.
    /// 8 is Bishop Pryce.
    /// 9 is Natalia. 
    /// 10 is Molotov.</param>
    /// <param name="changeInTrust">The amount this character's trust should be changed by.</param>
    public void UpdateCharacterTrust(int characterID, int changeInTrust)
    {
        if(characterID == 1)
        {
            trust_Richy += changeInTrust;
        }
        else if(characterID == 2)
        {
            trust_Esfir += changeInTrust;
        }
        else if(characterID == 3)
        {
            trust_Dmitri += changeInTrust;
        }
        else if(characterID == 4)
        {
            trust_Rigor += changeInTrust;
        }
        else if(characterID == 5)
        {
            trust_Petrov += changeInTrust;
        }
        else if(characterID == 6)
        {
            trust_Sacha += changeInTrust;
        }
        else if(characterID == 7)
        {
            trust_Lucky += changeInTrust;
        }
        else if(characterID == 8)
        {
            trust_BishopPryce += changeInTrust;
        }
        else if(characterID == 9)
        {
            trust_Natalia += changeInTrust;
        }
        else if(characterID == 10)
        {
            trust_Molotov += changeInTrust;
        }
    }

    #endregion 


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
