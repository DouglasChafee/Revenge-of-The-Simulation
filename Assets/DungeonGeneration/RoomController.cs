using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class RoomInfo
{
    public string name;
    public int X;
    public int Y;  
}

public class RoomController : MonoBehaviour
{
    public static RoomController instance;

    string currentWorldName = "Grassland";

    RoomInfo currentLoadRoomData;

    Room currRoom;

    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

    public List<Room> loadedRooms = new List<Room>();

    bool isLoadingRoom = false;
    bool spawnedBossRoom = false;
    bool updatedRooms = false;

    public CharBoolDoor getFloor;

    //public bool repeatRoom = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //LoadRoom("Start", 0, 0);
        //LoadRoom("2", 1, 0);
        //LoadRoom("Start", 0, 1);
        //LoadRoom("Start", 0, 2);


    }

    void Update()
    {
        UpdateRoomQueue();
    }

    void UpdateRoomQueue()
    {
        if (isLoadingRoom)
        {
            return;
        }

        if(loadRoomQueue.Count == 0)
        {
            if (!spawnedBossRoom)  // only called once
            {
                StartCoroutine(SpawnBossRoom());
            } else if(spawnedBossRoom && !updatedRooms)  // if boss is spawned and haven't updated doors, then update doors
            {
                foreach(Room room in loadedRooms)
                {
                    room.RemoveUnconnectedDoors();
                }
                updatedRooms = true;
            }
            return;
        }

        currentLoadRoomData = loadRoomQueue.Dequeue();
        isLoadingRoom = true;

        StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
    }

    IEnumerator SpawnBossRoom()  // if loadroomqueue is still at 0 in case the next room was not updated yet
    {
        spawnedBossRoom = true;
        yield return new WaitForSeconds(0.5f);
        if(loadRoomQueue.Count == 0)  // no more rooms to spawn
        {
            Room bossRoom = loadedRooms[loadedRooms.Count - 1];
            Room tempRoom = new Room(bossRoom.X, bossRoom.Y);  // using override method in Room
            Destroy(bossRoom.gameObject);  // gets rid of the normal room that was created potentially last line
            var roomToRemove = loadedRooms.Single(r => r.X == tempRoom.X && r.Y == tempRoom.Y);
            loadedRooms.Remove(roomToRemove);
            if(getFloor.floor == 1)
            {
                LoadRoom("FinalBossRoomEnd", tempRoom.X, tempRoom.Y);
            }
            if (getFloor.floor == 2)
            {
                LoadRoom("FinalBossRoom2End", tempRoom.X, tempRoom.Y);
            }
            if (getFloor.floor == 3)
            {
                LoadRoom("FinalBossRoom3End", tempRoom.X, tempRoom.Y);
            }
        }
    }

    public void LoadRoom(string name, int x, int y)
    {
        if(DoesRoomExist(x, y))  // if the room already exists we don't load the room
        {
            return;
        }
        RoomInfo newRoomData = new RoomInfo();
        newRoomData.name = name;
        newRoomData.X = x;
        newRoomData.Y = y;

        loadRoomQueue.Enqueue(newRoomData);
    }

    // Async Room loading
    IEnumerator LoadRoomRoutine(RoomInfo info)
    {
        string roomName = currentWorldName + info.name;

        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while(loadRoom.isDone == false)
        {
            yield return null;
        }
    }

    // set the room within the scene with the right coordinates in the world view
    public void RegisterRoom(Room room)
    {
        if (!DoesRoomExist(currentLoadRoomData.X, currentLoadRoomData.Y))
        {
            //repeatRoom = false;
            room.transform.position = new Vector3(
                currentLoadRoomData.X * room.Width,
                currentLoadRoomData.Y * room.Height,
                0
            );

            room.X = currentLoadRoomData.X;
            room.Y = currentLoadRoomData.Y;
            room.name = currentWorldName + "-" + currentLoadRoomData.name + " " + room.X + ", " + room.Y;
            room.transform.parent = transform;

            isLoadingRoom = false;



            if (loadedRooms.Count == 0)  // if no rooms loaded
            {
                NewCameraController.instance.currRoom = room;
            }

            if (loadedRooms.Count == 0)  // if no rooms loaded
            {
                CameraMovement.instance.currRoom = room;
            }

            loadedRooms.Add(room);
        }
        else
        {
            Destroy(room.gameObject);
            isLoadingRoom = false;
            //repeatRoom = true;
        }
    }

    public bool DoesRoomExist(int x, int y)
    {
        return loadedRooms.Find( item => item.X == x && item.Y == y) != null;
    }

    public Room FindRoom(int x, int y)
    {
        return loadedRooms.Find(item => item.X == x && item.Y == y);
    }

    public void OnPlayerEnterRoom(Room room)
    {
        NewCameraController.instance.currRoom = room;
        currRoom = room;
    }

    public void OnPlayerEnterRoom2(Room room)
    {
        CameraMovement.instance.currRoom = room;
        currRoom = room;
    }
}
