using UnityEngine;

[System.Serializable]
public class Garment
{
    public Sprite sprite;
    public string name;
    public GarmentCondition condition;
    public int price;
    public int value;
    public GarmentType type;


    public Garment(GarmentType? type = null, GarmentCondition? condition = null, Sprite? sprite = null, int? value = null, int? price = null) //If nothing in constructor, assign random values
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

        if (value != null)
        {
            this.value = (int)value;
        }
        else
        {
            this.value = GenerateValue();
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


    private int GenerateValue() //propably should these magic numbers somewhere else, but it is what it is
    {
        switch (type)
        {
            case GarmentType.Shirt:
                return Random.Range(5, 25);
            case GarmentType.Pants:
                return Random.Range(10, 35);
            case GarmentType.Shoes:
                return Random.Range(15, 44);
            default:
                return Random.Range(5, 25);
        }
    }
    private int GeneratePrice() {
        if (value == 0) { value = GenerateValue(); }
        switch (condition)
        {
            case GarmentCondition.Good:
                return (int)(value * 0.75);
            case GarmentCondition.Worn:
                return (int)(value * 0.50);
            case GarmentCondition.Bad:
                return (int)(value * 0.25);
            default:
                return (int)(value * 0.25);
        }
    }
}
