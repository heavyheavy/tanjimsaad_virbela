using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    [SerializeField]
    private int numberOfItems;

    [SerializeField]
    private Item itemPrefab;

    //This can be transformed into a property and limited as an optimization
    public List<Item> itemList = new List<Item>();

    //Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            var itemInstance = Instantiate(itemPrefab);
            itemInstance.transform.SetParent(transform);

            itemList.Add(itemInstance);
        }
    }

    public Item CreateNewItem()
    {
        var itemInstance = Instantiate(itemPrefab);
        itemInstance.transform.SetParent(transform);

        itemList.Add(itemInstance);

        return itemInstance;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
