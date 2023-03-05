using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGeneration : MonoBehaviour
{
    public GameObject RoomU;
    public GameObject RoomD;
    public GameObject RoomR;
    public GameObject RoomL;
    public GameObject RoomUD;
    public GameObject RoomLR;
    public GameObject RoomUR;
    public GameObject RoomDR;
    public GameObject RoomDL;
    public GameObject RoomUL;

    public GameObject StartU;
    public GameObject StartD;
    public GameObject StartR;
    public GameObject StartL;

    public GameObject FinishU;
    public GameObject FinishR;
    public GameObject FinishD;
    public GameObject FinishL;

    PlayerSpawn ps;
    StartAndFinish sf;
    POS pos;

    public int maxRoomsCount = 20;
    public int minRoomsCount = 10;
    public Vector2Int NewPos;
    public Vector2Int OldPos = new Vector2Int(0, 0);
    public Vector2Int Pos = new Vector2Int(0, 1);
    public Vector2 GlPos;
    public Vector2Int DirX;
    public Vector2Int DirY;
    int rx; int ry; int rxold; int ryold;
    public bool StartNewLevel = true;
    int plusX = 0, oldplusX;
    int plusY = 0, oldplusY;
    int OldDir = 0;
    int RoomVar = 0;

    List<int> roomslist = new List<int>();
    List<Vector2Int> roomsPositions = new List<Vector2Int>();
    List<GameObject> startRooms = new List<GameObject>();
    List<GameObject> RoomsVars = new List<GameObject>();

    void Update()
    {
        if (StartNewLevel)
        {
            transform.position = new Vector2(0, 0);
            O();
            StartNewLevel = false;
            NewRoomsCreating();
            ps = FindObjectOfType<PlayerSpawn>();
            sf = FindObjectOfType<StartAndFinish>();
            sf.RoomsDestroy = false;
            ps.kira = true;
        }
    }

    void O()
    {
        maxRoomsCount = 20;
        minRoomsCount = 10;
        Vector2Int NewPos;
        OldPos = new Vector2Int(0, 0);
        Pos = new Vector2Int(0, 1);
        Vector2 GlPos;
        Vector2Int DirX;
        Vector2Int DirY;
        rx = 0; ry = 0;
        StartNewLevel = true;
        plusX = 0; oldplusX = 0;
        plusY = 0; oldplusY = 0;
        OldDir = 0;
        RoomVar = 0;

        roomslist.Clear();
        roomsPositions.Clear();
        startRooms.Clear();
        RoomsVars.Clear();
    }


    void RoomsCreating()
    {
        int roomsCount = Random.Range(minRoomsCount, maxRoomsCount);
        Instantiate(StartR, transform.position, transform.rotation);
        roomsPositions.Add(Pos);
        roomsPositions.Add(OldPos);

        for (int i = 0; i < roomsCount; i++)
        {
            while (true)
            {
                //-----------------------------
                int r = Random.Range(0, 2);
                rxold = rx; ryold = ry;
                if (r == 0) { rx = Random.Range(-1, 2) + plusX; } //NewPos
                else { ry = Random.Range(-1, 2) + plusY; }
                NewPos = new Vector2Int(rx, ry);
                //-----------------------------
                DirX = new Vector2Int(OldPos.x - Pos.x, NewPos.x - Pos.x);
                DirY = new Vector2Int(OldPos.y - Pos.y, NewPos.y - Pos.y);
                print((DirX, DirY));
                //-----------------------------
                if (!roomsPositions.Contains(NewPos))
                {
                    roomsPositions.Add(NewPos);
                    if ((DirX.x == 0 & DirX.y == 0) & (DirY.x == -1 & DirY.y == 1))
                    {
                        Instantiate(RoomUD, Gl(Pos), transform.rotation);
                        plusX += Pos.x; plusY += Pos.x;
                    }
                    OldPos = Pos;
                    Pos = NewPos;
                }
                else { rx = rxold; ry = ryold; }
                //-----------------------------
                break;
            }
        }
    }

    void NewRoomsCreating()
    {
        startRooms.Add(StartU);
        startRooms.Add(StartR);
        startRooms.Add(StartD);
        startRooms.Add(StartL);

        int roomsCount = Random.Range(minRoomsCount, maxRoomsCount);
        int Dir = Random.Range(0, 3);
        Instantiate(startRooms[Dir], transform.position, transform.rotation);
        roomsPositions.Add((new Vector2Int(0, 0)));

        for (int i = 0; i < roomsCount; i++)
        {
            oldplusX = plusX; oldplusY = plusY;
            if (Dir == 0) { plusY++; RoomsVars.Add(RoomUD); RoomsVars.Add(RoomDR); RoomsVars.Add(RoomU); RoomsVars.Add(RoomDL); } //Предыдущая комната смотрит вверх
            if (Dir == 1) { plusX++; RoomsVars.Add(RoomUL); RoomsVars.Add(RoomLR); RoomsVars.Add(RoomDL); RoomsVars.Add(RoomU); } //Предыдущая комната смотрит вправо
            if (Dir == 2) { plusY--; RoomsVars.Add(RoomU); RoomsVars.Add(RoomUR); RoomsVars.Add(RoomUD); RoomsVars.Add(RoomUL); } //Предыдущая комната смотрит вниз
            if (Dir == 3) { plusX--; RoomsVars.Add(RoomUR); RoomsVars.Add(RoomU); RoomsVars.Add(RoomDR); RoomsVars.Add(RoomLR); } //Предыдущая комната смотрит влево

            while (true)
            {
                RoomVar = Random.Range(0, 4);
                if (RoomsVars[RoomVar] != RoomU)
                {
                    if (!roomsPositions.Contains(new Vector2Int(plusX, plusY + 1)) & RoomVar == 0) { roomsPositions.Add(new Vector2Int(plusX, plusY + 1)); break; }
                    if (!roomsPositions.Contains(new Vector2Int(plusX, plusY - 1)) & RoomVar == 2) { roomsPositions.Add(new Vector2Int(plusX, plusY - 1)); break; }
                    if (!roomsPositions.Contains(new Vector2Int(plusX + 1, plusY)) & RoomVar == 1) { roomsPositions.Add(new Vector2Int(plusX + 1, plusY)); break; }
                    if (!roomsPositions.Contains(new Vector2Int(plusX - 1, plusY)) & RoomVar == 3) { roomsPositions.Add(new Vector2Int(plusX - 1, plusY)); break; }
                }
            }
            Dir = RoomVar;
            Instantiate(RoomsVars[RoomVar], Gl(new Vector2(plusX, plusY)), transform.rotation);
            RoomsVars.Clear();

            OldDir = Dir;
        }

        if (Dir == 0) { plusY++; Instantiate(FinishD, Gl(new Vector2(plusX, plusY)), transform.rotation); }
        if (Dir == 1) { plusX++; Instantiate(FinishL, Gl(new Vector2(plusX, plusY)), transform.rotation); }
        if (Dir == 2) { plusY--; Instantiate(FinishU, Gl(new Vector2(plusX, plusY)), transform.rotation); }
        if (Dir == 3) { plusX--; Instantiate(FinishR, Gl(new Vector2(plusX, plusY)), transform.rotation); }

    }

    Vector2 Gl(Vector2 vctr2)
    {
        return new Vector2(vctr2.x * 32, vctr2.y * 18);
    }
}