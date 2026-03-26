using Unity.VisualScripting;
using UnityEngine;

public class MarketplaceGarmentItemUI : MonoBehaviour
{
    [Header ("UI items")]
    public TMPro.TextMeshProUGUI nameText;
    public TMPro.TextMeshProUGUI priceText;
    public UnityEngine.UI.Image icon;

    private Garment garment;
    private Inventory inventory;
    private Marketplace marketplace;

    public void Setup(Garment g, Inventory inv, Marketplace mark)
    {
        marketplace = mark;
        garment = g;
        inventory = inv;

        nameText.text = g.name;
        priceText.text = g.price.ToString();

    }

    public void OnClick()
    {
        inventory.AddGarment(garment);
        marketplace.RemoveGarment(garment);
    }
}
