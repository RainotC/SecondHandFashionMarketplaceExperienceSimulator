using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    int money = 1000; //set here only for testing, needs to be initialized when game starts
    [SerializeField]
    List<Garment> garments = new List<Garment>();

    public bool AddGarment(Garment garment)
    {
        if (garment.price > money)
        {
            Debug.Log($"Not enough money to buy {garment.name}. Current money: {money}, price: {garment.price}");
            return false;
        }
        money -= garment.price;
        garments.Add(garment);
        Debug.Log($"Added {garment.name} to inventory. Current money: {money}");
        return true;
    }



}
