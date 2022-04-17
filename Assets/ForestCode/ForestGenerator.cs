using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    public ForestGenerationData dungeonGenerationDataForest;
    private List<Vector2Int> dungeonRoomsForest;

    public string[] EmptyRooms = { "Empty", "3"}; //get random string room from this array of strings c#
    public string[] EmptyRooms2 = { "Level3" };
    public string[] EmptyRooms3 = { "Level3" };
    public string[] EmptyRooms4 = { "Level3", "Level10" };
    public string[] EmptyRooms5 = { "Level1", "Level2", "Level3", "Level4", "Level7", "Level10" };
    public string[] EmptyRooms8 = { "Level1", "Level2", "Level3" };
    public string[] EmptyRooms9 = { "Level10" };
    public string[] EmptyRooms10 = { "Level11", "Level12", "Level13", "Level14", "Level15" };

    private void Start()
    {
        dungeonRoomsForest = DungeonCrawlerController.GenerateForest(dungeonGenerationDataForest);
        SpawnRoomsForest(dungeonRoomsForest);
    }

    private void SpawnRoomsForest(IEnumerable<Vector2Int> rooms)
    {
        RoomController.instance.LoadRoom("Level3Start", 0, 0);
        foreach(Vector2Int roomLocation in rooms)
        {
                RoomController.instance.LoadRoom(EmptyRooms10.RandomItemForest().ToString(), roomLocation.x, roomLocation.y); //changed EmptyRooms.ToString() from Empty
         //RoomController.instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);
                Debug.Log(EmptyRooms10.RandomItemForest());
                //Debug.Log(EmptyRooms.ToString());
        }
    }
    
}

public static class ArrayExtensionsForest
{
    // This is an extension method. RandomItem() will now exist on all arrays.
    public static T RandomItemForest<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}

