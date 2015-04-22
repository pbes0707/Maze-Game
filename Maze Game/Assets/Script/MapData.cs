using UnityEngine;
using System.Collections;
using System.Collections.Generic;

enum MazeObjectType
{
    NORMAL = 9,
    BREAKABLE,
    DOOR,
    CUBE,
    KEY,
    SWITCH,
    ENEMY,
    PREFAB
}
class MapData
{
    public MapData()
    {
        beginPoints = new List<beginPoint>();
        endPoints = new List<Point>();
        objNormals = new List<NormalWall>();
    }
    public int chapter { get; set; }
    public int stage { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public List<beginPoint> beginPoints { get; set; }
    public List<Point> endPoints { get; set; }
    public List<NormalWall> objNormals { get; set; }
}
class Point
{
    /*public Point(int _x, int _y)
    {
        this.x = _x;
        this.y = _y;
    }*/
    public int x { get; set; }
    public int y { get; set; }
}
class beginPoint : Point
{
    /*public beginPoint(int _x, int _y, int _angle)
        : base(_x, _y)
    {
        this.angle = _angle;
    }*/
    public int angle { get; set; }
}

class NormalWall : Point
{
    /*public NormalWall(int _x, int _y, int _width, int _height)
        : base("normal", _x, _y)
    {
        this.width = _width;
        this.height = _height;
    }*/
    public int width { get; set; }
    public int height { get; set; }
}