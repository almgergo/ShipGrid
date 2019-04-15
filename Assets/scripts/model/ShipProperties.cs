using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class ShipProperties
{
    public int rows, columns;
    public int health;
    public ShipType shipType;


    public new string ToString => "rows: " + rows + ", columns: " + columns + ", health: " + health + ", type: " + shipType;
}

public enum ShipType
{
    BASIC,
    INTERCEPTOR
}