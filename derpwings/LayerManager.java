package derpwings;

import java.awt.*;
import java.awt.event.*;
import java.awt.image.*;
import java.util.*;
import java.io.*;
import javax.imageio.ImageIO;

import java.util.*; 

public class LayerManager extends ArrayList<DrawBoard>
{
    public int width, height, currentLayer = 0;
    boolean isDrawing = false, isEraser = false;
    Brush brush = new Brush();
    public LayerManager(int w, int h)
    {
        super();
        width = w;
        height = h;
        add(new DrawBoard(width, height));
    }
    
    public void addLayer()
    {
        add(new DrawBoard(width, height));
    }
    
    public void setStartPoint(Point p)
    {
        get(currentLayer).startPoint = p;
    }
    
    public void flickDraw(MouseEvent e, Brush b)
    {
        get(currentLayer).flickDraw(e, b);
    }
    
    public void drawImage(MouseEvent e, Brush b)
    {
        get(currentLayer).drawImage(e, b);
    }
    
    public void setOpacity(float f)
    {
        get(currentLayer).setOpacity(f);
    }
    
    public void setVisible(boolean b)
    {
        get(currentLayer).setVisible(b);
    }
    
    public BufferedImage getCanvas()
    {
        BufferedImage image = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        Graphics2D g2d = image.createGraphics();
        for(DrawBoard d : this) 
        {
            g2d.setComposite(AlphaComposite.getInstance(d.alphaLock == true? AlphaComposite.SRC_IN : AlphaComposite.SRC_OVER, 1f));
            g2d.drawImage(d.getReferenceImage(), 0, 0, null);
        }
        return image;
    }
    
    public void setBrushColor(Color c)
    {
        brush.setColor(c);
    }
}