using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "OpenDoorTimes", menuName = "SO_Door")]
public class OpenDoorTimes : ScriptableObject
{
    [SerializeField]
    public List<string> doors;
    public List<int> openTimes;
    public List<int> thisLoopDoorTimes;
    public int GetDoorTimes(string doorName)
    {
        //Debug.Log(doorName);
        return openTimes[GetDoorIndex(doorName)];
    }

    public void SetDoorTimes(string doorName)
    {
        openTimes[GetDoorIndex(doorName)] = openTimes[GetDoorIndex(doorName)] + 1;
    }

    public int GetThisLoopTimes(string doorName)
    {
        return thisLoopDoorTimes[GetDoorIndex(doorName)];
    }

    public void SetThisLoopTimes(string doorName)
    {
        thisLoopDoorTimes[GetDoorIndex(doorName)] = thisLoopDoorTimes[GetDoorIndex(doorName)] + 1;
    }


    public int GetDoorIndex(string doorName)
    {
        return doors.IndexOf(doorName);
    }
    
    public string GetDoorName(int index)
    {
        return doors[index];
    }


}