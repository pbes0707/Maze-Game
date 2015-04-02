using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeData
{
    public int chapter { get; set; }
    public int stage { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public List<beginPoint> beginPoints { get; set; }
    public List<Point> endPoints { get; set; }
    public List<mapData> mapDatas { get; set; }
    
}
public class mapData
{
    public string type { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class beginPoint : Point
{
    public int angle { get; set; }
}
public class Point
{
    public int x { get; set; }
    public int y { get; set; }
}