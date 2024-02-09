package derpwings;

import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import javax.swing.*;

import java.util.*;

public class Canvas extends ArrayList<BufferedImage> 
{
    // readonly values goes here:
    public static final int PAINT = 0;
    public static final int ERASER = 1;
    public static final int FILL = 2;
    public static final int LASSO = 3;
    public static final int MISC = 4;

    // static values goes here:
    public static boolean isDrawing = false;
    public static BufferedImage layerControl;
    public static Point startPoint, endPoint; // Store starting point of each drag
    public static float opacity = .25f;
    public static Color color = Color.BLACK;
    public static int currentLayer = 0;
    
    // do not get confused with dimensions of canvas and the brush...
    public static int width, height;    
    public static int brushWidth = 10; // Adjust width as needed
    public static int brushHeight = 10; // Adjust height as needed
    public static int mode;               

    public Canvas(int w, int h) 
    {
        super();
        width = w;
        height = h;
        add(new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB)); // the first image
    }
    
    public void paintProcess(int width, int height, MouseEvent e)
    {
        Graphics2D paintGraphics = get(currentLayer).createGraphics();
        endPoint = e.getPoint();
        int dx = endPoint.x - startPoint.x;
        int dy = endPoint.y - startPoint.y;
        int steps = Math.max(Math.abs(dx), Math.abs(dy));
        double xIncrement = (double) dx / steps;
        double yIncrement = (double) dy / steps;
                            
        AlphaComposite alphaComposite = AlphaComposite.getInstance(AlphaComposite.SRC_OVER, color.getAlpha() / 255f / Math.max(width, height));
        paintGraphics.setComposite(alphaComposite);
        paintGraphics.setColor(color);
                        
        // brushing input fixed!!!
        for (int i = 0; i <= steps; i++) 
        {
            int x = (int) (startPoint.x + i * xIncrement) == 0? startPoint.x : (int) (startPoint.x + i * xIncrement);
            int y = (int) (startPoint.y + i * yIncrement) == 0? startPoint.y : (int) (startPoint.y + i * yIncrement);
            paintGraphics.fillOval(x, y, width, height);
        }
        startPoint = e.getPoint();
        paintGraphics.dispose();
    }
    
    public static Color getColor()
    {
        return color;
    }
    
    public static int getWidth()
    {
        return width;
    }
        
    public static int getHeight()
    {
        return height;
    }
    
    public static int getBrushWidth()
    {
        return brushWidth;
    }
    
    public static int getBrushHeight()
    {
        return brushHeight;
    }
    
    public static void main(String[] args) 
    {
        SwingUtilities.invokeLater(() -> {
            JFrame frame = new JFrame("Canvas Example");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setLayout(null);


            frame.setSize(new Dimension(1280, 720));
            frame.setLocationRelativeTo(null);
            frame.setVisible(true);
        });
    }
}
