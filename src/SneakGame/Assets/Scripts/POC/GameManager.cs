using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject SquareRoom;
    public GameObject LongRoom;

    public Vector3[] roomPosition;

    private GameObject[] Structures;
    private int RandRoomChance;

    private int[] RotationChance = new int[] { 0, 45, 90 };

    public List<GameObject> roomList;

    // Start is called before the first frame update
    void Start()
    {
        Structures = new GameObject[] { SquareRoom, LongRoom };
        reshuffle(roomPosition);
        SetRoom();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetRandom()
    {
        RandRoomChance = Random.Range(0, Structures.Length);
    }
    
    private void SetRoom()
    {
        for (int i = 0; i < roomPosition.Length; i++)
        {
            GetRandom();
            GameObject room = Instantiate(Structures[RandRoomChance]);
            room.transform.position = new Vector3(roomPosition[i].x, roomPosition[i].y, 0.1f);

            Vector3 newRotate = new Vector3(0, 0, RotationChance[Random.Range(0, RotationChance.Length)]);
            room.transform.Rotate(newRotate);

            roomList.Add(room);

        }
    }

    //"chaging the room by actually removing the gameobjects and calling back the method"
    public void ChangeRoom()
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            Destroy(roomList[i]);
            
        }
        roomList.Clear();
        SetRoom();
    }

    //method with alternation from https://forum.unity.com/threads/randomize-array-in-c.86871/
    void reshuffle(Vector3[] value)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < value.Length; t++)
        {
            var tmp = value[t];
            int r = Random.Range(t, value.Length);
            value[t] = value[r];
            value[r] = tmp;
        }
    }
}
