using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField]
    private int numberOfItems;

    [SerializeField]
    private Generic itemPrefab;

    //This can be transformed into a property and limited as an optimization
    public List<Generic> genericsList = new List<Generic>();

    //Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            var itemInstance = Instantiate(itemPrefab);
            itemInstance.transform.SetParent(transform);

            genericsList.Add(itemInstance);
        }
    }

    /// <summary>
    /// Function creates a new instance of the prefab and 
    /// adds it to the list
    /// </summary>
    /// <returns></returns>
    public Generic CreateNewGeneric()
    {
        var itemInstance = Instantiate(itemPrefab);
        itemInstance.transform.SetParent(transform);

        genericsList.Add(itemInstance);

        return itemInstance;
    }

}
