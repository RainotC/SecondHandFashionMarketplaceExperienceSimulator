using UnityEngine;

[System.Serializable]
public class Garment
{
    public Sprite sprite;
    public string name;
    public GarmentCondition condition;
    public int price;
    public GarmentType type;


    public Garment(GarmentType? type = null, GarmentCondition? condition = null, Sprite? sprite = null, int? price = null) //If nothing in constructor, assign random values
    {
        name = "Garment " + Random.Range(1, 1000); 
        if (type != null)
        {
            this.type = (GarmentType)type;
        }
        else
        {
            this.type = (GarmentType)Random.Range(0, 3);
        }

        if (sprite != null)
        {
            this.sprite = (Sprite)sprite;
        }
        else
        {
            this.sprite = null;
        }

        if (condition != null)
        {
            this.condition = (GarmentCondition)condition;
        }
        else
        {
            this.condition = (GarmentCondition)Random.Range(0, 3);
        }

        if (price != null)
        {
            this.price = (int)price;
        }
        else
        {
            this.price = GeneratePrice();
        }
    }


    int GeneratePrice() //propably should these magic numbers somewhere else, but it is what it is
    {
        int basePrice = 0;
        switch (type)
        {
            case GarmentType.Shirt:
                basePrice = Random.Range(5, 25);
                break;
            case GarmentType.Pants:
                basePrice = Random.Range(10, 35);
                break;
            case GarmentType.Shoes:
                basePrice = Random.Range(15, 44);
                break;
        }
        switch (condition)
        {
            case GarmentCondition.Good:
                return basePrice;
            case GarmentCondition.Worn:
                return (int)(basePrice * 0.75);
            case GarmentCondition.Bad:
                return (int)(basePrice * 0.50);
            default:
                return basePrice;
        }
    }
}
