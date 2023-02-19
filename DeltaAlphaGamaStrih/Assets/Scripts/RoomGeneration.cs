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
    public Vector2Int NewPos;
    public Vector2 Pos;
    int rx; int ry; int rxold; int ryold;
    int plusX = 0;
    int plusY = 0;
    List<int> roomslist = new List<int>();
    List<Vector2Int> roomsPositions = new List<Vector2Int>();

    void Start()
    {
        //A();
        RoomsCreating();
    }

    void A()
    {
        int roomsCount = Random.Range(minRoomsCount, maxRoomsCount);
        int stRoomsCount = Random.Range(roomsCount / 2, roomsCount / (10 / 7));
        int bgRoomsCount = roomsCount - stRoomsCount;
        for (int i = 0; i < stRoomsCount; i++) { roomslist.Add(0); }
        //for (int i = 0; i < bgRoomsCount; i++) { roomslist.Add(1); }
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
        roomsPositions.Add(Vector2Int.zero);
        
        for (int i = 0; i < 10; i++)
        {
            print(plusX);
            while (true)
            {
                int r = Random.Range(0, 2);
                rxold = rx; ryold = ry;
                if (r == 0) { rx = Random.Range(-1, 2) + plusX; }
                else { ry = Random.Range(-1, 2) + plusY; }
                NewPos = new Vector2Int(rx, ry);
                Pos = new Vector2(rx * 32, ry * 18);
                if (!roomsPositions.Contains(NewPos)) { plusX = NewPos.x; plusY = NewPos.y; roomsPositions.Add(NewPos); Instantiate(StR, Pos, transform.rotation); break; }
                else { rx = rxold; ry = ryold; print(123); }
            }
        }
    }
}