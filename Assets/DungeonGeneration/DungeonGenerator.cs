using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonGenerationData dungeonGenerationData;
    private List<Vector2Int> dungeonRooms;

    public string[] EmptyRooms = { "Empty", "3"}; //get random string room from this array of strings c#
    public string[] EmptyRooms2 = { "Level3" };
    public string[] EmptyRooms3 = { "Level3" };
    public string[] EmptyRooms4 = { "Level3", "Level10" };
    public string[] EmptyRooms5 = { "Level1", "Level2", "Level3", "Level4", "Level7", "Level10" };
    public string[] EmptyRooms8 = { "Level1", "Level2", "Level3"};
    public string[] EmptyRooms9 = { "Level1", "Level2", "Level3", "Level4", "Level5" };

    private void Start()
    {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        RoomController.instance.LoadRoom("Level1Start", 0, 0);
        foreach(Vector2Int roomLocation in rooms)
        {
                RoomController.instance.LoadRoom(EmptyRooms9.RandomItem().ToString(), roomLocation.x, roomLocation.y); //changed EmptyRooms.ToString() from Empty
         //RoomController.instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);
                Debug.Log(EmptyRooms9.RandomItem());
                //Debug.Log(EmptyRooms.ToString());
        }
    }
    
}

public static class ArrayExtensions
{
    // This is an extension method. RandomItem() will now exist on all arrays.
    public static T RandomItem<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}

