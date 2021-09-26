using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    

    //Provides access to the itemController object
    [SerializeField]
    private ItemController itemController;

    //Provides access to the botsController object
    [SerializeField]
    private BotController botsController;
    
    //Used to keep track of the object that is currently "highlighted"
    private Generic CurrentItemHighlighted;

    //A list that keeps track of both of the items/bots in order to iterate through a single
    //list to get the closest object.
    private List<Generic> combinedList = new List<Generic>();

    // Start is called before the first frame update
    void Start()
    {
        //Combine the bots list and the items list
        combinedList.AddRange(itemController.genericsList);
        combinedList.AddRange(botsController.genericsList);

        //Get the closest item to the player object
        //and cache it in Start()
        var item = GetClosestItem();

        //Change the color of the object
        item.HighlightItem();

        //Keep track of the current highlighted item
        CurrentItemHighlighted = item;
    }


    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var newItem = itemController.CreateNewGeneric();
            combinedList.Add(newItem);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            var newBot = botsController.CreateNewGeneric();
            combinedList.Add(newBot);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -1);
        }

        //Get the closest item on every late update 
        //This function can be moved away from the Update function in order to
        //optimize the code futher
        var closestItem = GetClosestItem();

        //Check to see if the closest item has changed 
        //We dont want to be constantly doing stuff if nothing has changed
        //This can be done more elegantly with an event driven system with 
        //handlers and delegates etc
        //I am keeping it simple for the sake of it being just a homework assignment
        if (closestItem != CurrentItemHighlighted && closestItem != null && CurrentItemHighlighted != null)
            {
                //change the old item to the default color
                CurrentItemHighlighted.ResetItemColorToDefault();

                //change the new item to the highlighted color
                closestItem.HighlightItem();

                //update CurrentItemHighlighted to the new item highlighted
                CurrentItemHighlighted = closestItem;
        }
    }

    /// <summary>
    /// Return the closest item to the player object
    /// </summary>
    /// <returns></returns>
    private Generic GetClosestItem()
    {
        Generic closest = null;
       
        float ShortestDistance = Vector3.Distance(transform.position, combinedList[0].transform.position);
        
        //Loop through all objects and find closest
        foreach (var item in combinedList)
        {
            float Distance = Vector3.Distance(transform.position, item.transform.position);
            if (Distance < ShortestDistance)
            {            
                closest = item;
                ShortestDistance = Distance;
            }
        }
        return closest;
    }
}
