using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankInfo
{
    public string name;
    public int score;
    public float time;

    public RankInfo(string name, int score, float time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }

    public RankInfo()
    {
    }
}

public class RankData
{
    public List<RankInfo> rankList;
}