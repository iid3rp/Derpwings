package derpwings;

import java.awt.*;
import java.awt.event.*;
import java.awt.image.*;
import javax.swing.*;

import java.util.*;

public class DrawBoard
{
    public BufferedImage brushBuffer;
    public BufferedImage canvasBuffer;
    public BufferedImage referenceImage;
    public float opacity;
    public boolean visibility, eraser = false, clippable, alphaLock = false, antialias = true;
    public Point startPoint, endPoint;
    public int width, height;
    
    public DrawBoard(int w, int h)
    {
        width = w;
        height = h;
        brushBuffer = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        opacity = 1f;
        visibility = true;
    }
    
    public void setOpacity(float f)
    {
        opacity = f;
    }
    
    public void setVisible(boolean b)
    {
        visibility = b;
    }
    
    public void flickDraw(MouseEvent e, Brush b)
    {
        Graphics2D g2d = brushBuffer.createGraphics();
        g2d.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_OVER, 1f)); 
        Point p = e.getPoint();
        g2d.drawImage(b.getImage(), p.x - b.getImage().getWidth() / 2, p.y - b.getImage().getHeight() / 2, null);
        g2d.dispose();
    }
    
    public void drawImage(MouseEvent e, Brush b)
    {
        endPoint = e.getPoint();
        int dx = endPoint.x - startPoint.x;
        int dy = endPoint.y - startPoint.y;
        int steps = Math.max(Math.abs(dx), Math.abs(dy));
        double xIncrement = (double) dx / steps;
        double yIncrement = (double) dy / steps;

        Graphics2D g2d = brushBuffer.createGraphics(); 
        g2d.setRenderingHints(new RenderingHints(RenderingHints.KEY_ANTIALIASING, antialias == true? RenderingHints.VALUE_ANTIALIAS_ON : RenderingHints.VALUE_ANTIALIAS_OFF)); // when it enables/disables anti-alias when painting with a brush 
        for (int i = 0; i <= steps; i++) 
        {
            int x = (int) (startPoint.x + i * xIncrement) == 0? startPoint.x : (int) (startPoint.x + i * xIncrement);
            int y = (int) (startPoint.y + i * yIncrement) == 0? startPoint.y : (int) (startPoint.y + i * yIncrement);
            g2d.drawImage(b.brushImage, x - b.getImage().getWidth() / 2, y - b.getImage().getHeight() / 2, null);
        }
        steps = 0;
        dx = 0;
        dy = 0;
        xIncrement = 0f;
        yIncrement = 0f;
        startPoint = e.getPoint();
        g2d.dispose();
    }
    
    // merge the both draw and the canvas layer itself
    public Image getReferenceImage()
    {
        Graphics2D g2d = referenceImage.createGraphics();
        g2d.setComposite(AlphaComposite.getInstance(eraser != true? AlphaComposite.SRC_OVER : AlphaComposite.CLEAR, opacity));
        g2d.setRenderingHints(new RenderingHints(RenderingHints.KEY_ANTIALIASING, antialias == true? RenderingHints.VALUE_ANTIALIAS_ON : RenderingHints.VALUE_ANTIALIAS_OFF));
        g2d.drawImage(canvasBuffer, 0, 0, null);
        g2d.drawImage(brushBuffer, 0, 0, null);
        return referenceImage;
    }
    
    // refresh the whole canvas itself (when the layer has been painted...)/
    public void zzz()
    {
        Graphics2D canvasGraphics = canvasBuffer.createGraphics();
        Graphics2D brushGraphics = brushBuffer.createGraphics();
        
        canvasGraphics.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_OVER, opacity));
        brushGraphics.drawImage(brushBuffer, 0, 0, null);
        canvasGraphics.setComposite(AlphaComposite.getInstance(AlphaComposite.CLEAR, 1f));
        canvasGraphics.fillRect(0, 0, width, height);
    }
}