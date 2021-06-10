using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates and stores all
//item types (may be duplicates of various items) in the game
//goes on the game manager.

//So like first it makes the "concept" of an item
//and then if the player/programmer wants,
//you can make the actual item and then
//put it in the world space or the player inventory
public class ItemGenerator : MonoBehaviour
{
    //sort of the hollow "concept of item"
    public LinkedList<P_Item> itemTypes;
    public static int typeCount = 0;
    public static int itemCount = 0;

    public static bool itemTypesGenerated = false;

    //all items in game
    public LinkedList<P_Item> itemStorage;
    private void Start()
    {
        itemTypes = new LinkedList<P_Item>();
        itemStorage = new LinkedList<P_Item>();
    }
    //Run on start from GameManager
    public void GenerateItemTypes() { 
        if (!itemTypesGenerated){
      
            itemTypesGenerated = true;
            for (int i = 0; i < 5; i++)
            {
                itemCount++;
                itemTypes.AddLast(new P_Item(P_Item.ItemState.doesntExist, typeCount, itemCount));
                typeCount++;

            }
            
            print("Item types generated.");
        }
        else if (itemTypesGenerated){
            print("Item types already generated, no effect");
        }
    }
    

    //Generation type: in another item, outside another item
    public P_Item GeneratePhyiscalItem(int itemTypeID, int generationType)
    {
        P_Item tempItem = null;
        foreach(P_Item i in itemTypes)
        {
            if (itemTypeID == i.ItemTypeID)
            {
                tempItem = i;
                break;
            }
        }
        itemStorage.AddLast(tempItem);
        return null;
    }

    //Deletion type: in another item, outside another item
    public void DeletePhysicalItem(int itemID, int deletionType)
    {
        foreach(P_Item i in itemStorage)
        {
            if(itemID == i.ItemID)
            {
                itemStorage.Remove(i);
                break;
            }
        }
    }


    
}
