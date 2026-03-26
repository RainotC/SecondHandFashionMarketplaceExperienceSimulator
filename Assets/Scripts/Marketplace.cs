using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Marketplace : MonoBehaviour
{
    [SerializeField]
    List<Garment> currentGarments = new List<Garment>();

    public event Action OnMarketplaceUpdated;
    void Start()
    {
        CreateRandomGarmentList(10);
    }

    void CreateRandomGarmentList(int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            Garment garment = new Garment();
            currentGarments.Add(garment);
        }
        OnMarketplaceUpdated?.Invoke();
    }
    public List<Garment> GetItems()
    {
        return currentGarments;
    }

    public void RemoveGarment(Garment garment)
    {
        if (currentGarments.Contains(garment))
        {
            currentGarments.Remove(garment);
            OnMarketplaceUpdated?.Invoke();
        }
        else
        {
            Debug.LogWarning("Attempted to remove a garment that is not in the marketplace.");
        }
    }
}
