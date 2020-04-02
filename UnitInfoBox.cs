using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoBox : MonoBehaviour
{
    public Text health;
    public Text armor;
    public Text damage;
    public Text range;

    public GameObject unitInfo;

    TurnManager gm;

    public int huphuphay;

    void Start()
    {
        unitInfo.SetActive(false);
        gm = FindObjectOfType<TurnManager>();
        huphuphay = 0;
    }

    
    void Update()
    {
        health.text = gm.unitSelected.health.ToString() + " health";
        armor.text = gm.unitSelected.armor.ToString() + " armor";
        damage.text = gm.unitSelected.attackDamage.ToString() + " damage";
        range.text = gm.unitSelected.attackRange.ToString() + " range";

    }


    public void ShowBox()
    {
        Debug.Log("Show Info Box");
        huphuphay = 1;
        unitInfo.SetActive(true);
    }

    public void HideBox()
    {
        huphuphay = 0;
        unitInfo.SetActive(false); 
    }
}
