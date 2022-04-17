using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavesGenerator : MonoBehaviour
{
    public CaveGenerationData caveGenerationData;
    private List<Vector2Int> caveRooms;

    public string[] EmptyRooms = { "Empty", "3"}; //get random string room from this array of strings c#
    public string[] EmptyRooms2 = { "Level3" };
    public string[] EmptyRooms3 = { "Level3" };
    public string[] EmptyRooms4 = { "Level3", "Level10" };
    public string[] EmptyRooms5 = { "Level1", "Level2", "Level3", "Level4", "Level7", "Level10" };
    public string[] EmptyRooms6 = { "Level7" };
    public string[] EmptyRooms7 = { "Level6", "Level7", "Level8", "Level9", "Level10" };

    private void Start()
    {
        caveRooms = DungeonCrawlerController.GenerateCave(caveGenerationData);
        SpawnCave(caveRooms);
    }

    private void SpawnCave(IEnumerable<Vector2Int> rooms)
    {
        RoomController.instance.LoadRoom("Level6", 0, 0);
        foreach(Vector2Int roomLocation in rooms)
        {
                RoomController.instance.LoadRoom(EmptyRooms7.RandomItemCave().ToString(), roomLocation.x, roomLocation.y); //changed EmptyRooms.ToString() from Empty
         //RoomController.instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);
                Debug.Log(EmptyRooms7.RandomItemCave());
                //Debug.Log(EmptyRooms.ToString());
        }
    }
    
}

public static class CaveArrayExtensions
{
    // This is an extension method. RandomItem() will now exist on all arrays.
    public static T RandomItemCave<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}

