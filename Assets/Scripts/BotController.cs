using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    [SerializeField]
    private int numberOfItems;

    [SerializeField]
    private Bot botPrefab;

    //This can be transformed into a property as an optimization
    public List<Bot> botList = new List<Bot>();

    //Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfItems; i++)
        {
            var botInstance = Instantiate(botPrefab);
            botInstance.transform.SetParent(transform);

            botList.Add(botInstance);
        }
    }


    public Bot CreateNewBot()
    {
        var botInstance = Instantiate(botPrefab);
        botInstance.transform.SetParent(transform);

        botList.Add(botInstance);

        return botInstance;
    }

}
