using System.Collections.Generic;
using UnityEngine;

public class MarketplaceListUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Marketplace marketplace;
    [SerializeField] private Inventory inventory;

    [Header("UI")]
    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject itemPrefab;

    private void OnEnable()
    {
        if (marketplace != null)
            marketplace.OnMarketplaceUpdated += RefreshUI;
    }

    private void OnDisable()
    {
        if (marketplace != null)
            marketplace.OnMarketplaceUpdated -= RefreshUI;
    }



    private void CreateItem(Garment garment)
    {
        GameObject obj = Instantiate(itemPrefab, contentParent);

        var ui = obj.GetComponent<MarketplaceGarmentItemUI>();

        if (ui == null)
        {
            Debug.LogError("Prefab missing MarketplaceGarmentItemUI!");
            return;
        }

        ui.Setup(garment, inventory, marketplace);

        // Button hookup
        var button = obj.GetComponent<UnityEngine.UI.Button>();
        button.onClick.RemoveAllListeners(); 
        button.onClick.AddListener(ui.OnClick);
    }

   private void RefreshUI()
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        var garments = marketplace.GetItems();
        foreach (var garment in garments)
        {
            CreateItem(garment);
        }
    }
}
