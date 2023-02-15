using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public GameObject StR;
    public GameObject BgR;
    public GameObject StartR;
    public int maxRoomsCount = 20;
    public int minRoomsCount = 10;
    //int plusX = 0;
    int plusY = 7;
    List<int> roomslist = new List<int>();
    void Start()
    {
        A();
        RoomsCreating();
    }

    void A()
    {
        int roomsCount = Random.Range(minRoomsCount, maxRoomsCount);
        int stRoomsCount = Random.Range(roomsCount / 2, roomsCount / (10 / 7));
        int bgRoomsCount = roomsCount - stRoomsCount;
        for (int i = 0; i < stRoomsCount; i++) { roomslist.Add(0); }
        for (int i = 0; i < bgRoomsCount; i++) { roomslist.Add(1); }
        for (int i = 0; i < roomsCount; i++)
        {
            int r = Random.Range(0, roomslist.Count);
            int a = roomslist[i];
            roomslist[i] = roomslist[r];
            roomslist[r] = a;
        }
    }

    void RoomsCreating()
    {
        Instantiate(StartR, transform.position, transform.rotation);
        for (int i = 0; i < roomslist.Count; i++)
        {
            if (roomslist[i] == 0)
            {
                plusY += 10;
                Vector2 pos = new Vector2(0, plusY);
                Instantiate(StR, pos, transform.rotation);
                //plusX -= 8;
                plusY += 9;
            }
            if (roomslist[i] == 1)
            {
                plusY -= 4;
                Vector2 pos = new Vector2(-10, plusY);
                Instantiate(BgR, pos, transform.rotation);
                plusY += 36;
            }
        }
    }
}