using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<Garment> garments = new List<Garment>();

    public void AddGarment(Garment garment)
    {
        garments.Add(garment);
        Debug.Log($"Added {garment.name} to inventory.");
    }



}
