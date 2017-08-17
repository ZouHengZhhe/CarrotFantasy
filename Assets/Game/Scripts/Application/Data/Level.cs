using System;
using System.Collections.Generic;

public class Level
{
    //名字
    public string Name;

    //背景
    public string Background;

    //路径
    public string Road;

    //初始金币
    public int InitScore;   

    //炮塔可放置的位置
    public List<Point> Holder=new List<Point>();

    //怪物行走路径
    public List<Point> Path=new List<Point>();

    //出怪回合信息
    public List<Round> Rounds=new List<Round>();

}
