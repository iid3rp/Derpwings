package derpwings;

import java.awt.*;
import java.awt.image.*;
import java.util.*;
import java.io.*;
import javax.imageio.ImageIO;

import java.util.*; 

public class LayerManager extends ArrayList<DrawBoard>
{
    public int width, height, currentLayer = 1;
    public LayerManager(int width, int height)
    {
        super();
        width = width;
        height = height;
        add(new DrawBoard(width, height));
    }
    
    public void addLayer()
    {
        add(new DrawBoard(width, height));
    }
    
    public void drawImage()
    {
        get(currentLayer).drawImage(null, null);
    }
    
    public void setOpacity(float f)
    {
        get(currentLayer).setOpacity(f);
    }
    
    public void setVisible(boolean b)
    {
        get(currentLayer).setVisible(b);
    }
}