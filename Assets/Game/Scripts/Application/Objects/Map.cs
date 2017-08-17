using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用于描述一个关卡地图的状态
public class Map : MonoBehaviour
{
    #region 常量

    public const int RowCount = 8;   //行数
    public const int ColumnCount = 12; //列数

    #endregion

    #region 事件



    #endregion

    #region 字段

    float MapWidth;//地图宽
    float MapHeight;//地图高

    float TileWidth;//格子宽
    float TileHeight;//格子高

    List<Tile> m_grid = new List<Tile>(); //格子集合
    List<Tile> m_road = new List<Tile>(); //路径集合

    public bool DrawGizmos = true; //是否绘制网格

    #endregion

    #region 属性



    #endregion

    #region 方法



    #endregion

    #region Unity回调



    #endregion

    #region 事件回调



    #endregion

    #region 帮助方法

    //计算地图大小，格子大小
    void CalculateSize()
    {
        Vector3 leftDown = new Vector3(0, 0);
        Vector3 rightUp = new Vector3(1, 1);

        Vector3 p1 = Camera.main.ViewportToWorldPoint(leftDown);
        Vector3 p2 = Camera.main.ViewportToWorldPoint(rightUp);

        MapWidth = (p2.x - p1.x);
        MapHeight = (p2.y - p1.y);

        TileWidth = MapWidth / ColumnCount;
        TileHeight = MapHeight / RowCount;
    }

    //获取格子中心点所在的世界坐标
    Vector3 GetPosition(Tile t)
    {
        return new Vector3(
                -MapWidth / 2 + (t.X + 0.5f) * TileWidth,
                -MapHeight / 2 + (t.Y + 0.5f) * TileHeight,
                0
            );
    }

    //根据格子索引号获得格子
    Tile GetTile(int tileX, int tileY)
    {
        int index = tileX + tileY * ColumnCount;

        if (index < 0 || index >= m_grid.Count)
            return null;

        return m_grid[index];
    }

    //获取鼠标下面的格子
    Tile GetTileUnderMouse()
    {
        Vector2 wordPos = GetWorldPosition();
        int col = (int)((wordPos.x + MapWidth / 2) / TileWidth);
        int row = (int)((wordPos.y + MapHeight / 2) / TileHeight);
        return GetTile(col, row);
    }

    //获取鼠标所在位置的世界坐标
    Vector3 GetWorldPosition()
    {
        Vector3 viewPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        return worldPos;
    }

    #endregion

}
