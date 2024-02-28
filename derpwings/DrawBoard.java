package derpwings;

import java.awt.*;
import java.awt.event.*;
import java.awt.image.*;
import javax.swing.*;

import java.util.*;

public class DrawBoard
{
    // hello World!
    public BufferedImage canvas;
    public Image referenceImage;
    public float opacity;
    public boolean visibility, clippable, alphaLock = false;;
    public Point startPoint, endPoint;
    
    public DrawBoard(int width, int height)
    {
        canvas = new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB);
        opacity = 1f;
        visibility = true;
        referenceImage = canvas;
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
        Graphics2D g2d = canvas.createGraphics();
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

        Graphics2D g2d = canvas.createGraphics();
        if(alphaLock) g2d.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_IN, 1f));
        else g2d.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_OVER, 1f));  
        g2d.setRenderingHints(new RenderingHints(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON)); // when it enables anti-alias when painting with a brush 
        // brushing input fixed!!!
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
}