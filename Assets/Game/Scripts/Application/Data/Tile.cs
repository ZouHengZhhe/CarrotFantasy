using System;
using System.Collections.Generic;

//格子信息
public class Tile
{
    public int X;
    public int Y;
    public bool CanHold;  //是否可以放置塔
    public Object Data;   //格子所保存的数据

    public Tile(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public override string ToString()
    {
        return string.Format("[X:{0},Y:{1},CanHold:{2}]",this.X,this.Y,this.CanHold);
    }
}
