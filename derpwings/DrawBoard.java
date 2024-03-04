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
    public float opacity;
    public boolean visibility, eraser = false, clippable, alphaLock = false, antialias = true;
    public Point startPoint, endPoint;
    public int width, height;
    
    public DrawBoard(int w, int h)
    {
        width = w;
        height = h;
        brushBuffer = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        canvasBuffer = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        opacity = .5f;
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
        // setting this aside tbh,.,.,..
        Graphics2D g2d = brushBuffer.createGraphics();
        g2d.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_OVER, opacity)); 
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

        // trenary value changing from brush to eraser ruleset :3
        Graphics2D g2d = eraser == true? canvasBuffer.createGraphics() : brushBuffer.createGraphics(); 
        g2d.setRenderingHints(new RenderingHints(RenderingHints.KEY_ANTIALIASING, antialias == true? RenderingHints.VALUE_ANTIALIAS_ON : RenderingHints.VALUE_ANTIALIAS_OFF)); // when it enables/disables anti-alias when painting with a brush 
        g2d.setComposite(AlphaComposite.getInstance(eraser == true? AlphaComposite.CLEAR : AlphaComposite.SRC_OVER, opacity));
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
        BufferedImage referenceImage = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        Graphics2D g2d = referenceImage.createGraphics();
        g2d.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_OVER, opacity));
        g2d.drawImage(canvasBuffer, 0, 0, null);
        g2d.drawImage(brushBuffer, 0, 0, null);
        g2d.dispose();
        return referenceImage;
    }
    
    // stamp the whole brush trace to the canvas so that itll be iterate itself (when the layer has been painted...)
    public void stampBrush()
    {
        // stamping it first
        Graphics2D g2d1 = canvasBuffer.createGraphics();
        g2d1.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_OVER, opacity));
        g2d1.drawImage(brushBuffer, 0, 0, null);
        g2d1.dispose();

        // and then the brushBuffer resets once again!!1
        Graphics2D g2d2 = brushBuffer.createGraphics();
        g2d2.setComposite(AlphaComposite.getInstance(AlphaComposite.CLEAR, 1f));
        g2d2.fillRect(0, 0, width, height);
        g2d2.dispose();
    }
}