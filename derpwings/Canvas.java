package derpwings;

import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import javax.swing.*;

import java.util.*;

public class Canvas
{ 
    // array lists goes here:
    public static ArrayList<Boolean> appear = new ArrayList<>();
    public static ArrayList<Float> opacity = new ArrayList<>();
    public static ArrayList<BufferedImage> image = new ArrayList<>();
    public static ArrayList<AlphaComposite> composite = new ArrayList<>();
       
    // other values goes here:
    public static boolean isDrawing = true;
    public static BufferedImage layerControl;
    public static Point startPoint, endPoint; // Store starting point of each drag
    public static float brushOpacity = .25f;
    public static Color color = Color.BLACK;
    public static int currentLayer = 0;
    
    // do not get confused with dimensions of canvas and the brush...
    public static int width, height;    
    public static int brushWidth = 10; // Adjust width as needed
    public static int brushHeight = 10; // Adjust height as needed
    public static int mode;                 

    public Canvas(int w, int h) 
    {
        // array lists goes here:
        super();
        width = w;
        height = h;
        image.add(new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB)); // the first image
        opacity.add(1f);
        appear.add(true);
    }
    
    public static void paintProcess(int width, int height, MouseEvent e)
    {
        Graphics2D paintGraphics = image.get(currentLayer).createGraphics();
        endPoint = e.getPoint();
        int dx = endPoint.x - startPoint.x;
        int dy = endPoint.y - startPoint.y;
        int steps = Math.max(Math.abs(dx), Math.abs(dy));
        double xIncrement = (double) dx / steps;
        double yIncrement = (double) dy / steps;
                            
        if(isDrawing) 
        {
            paintGraphics.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_OVER, 1f));
            paintGraphics.setColor(color);
                        
            // brushing input fixed!!!
            for (int i = 0; i <= steps; i++) 
            {
                int x = (int) (startPoint.x + i * xIncrement) == 0? startPoint.x : (int) (startPoint.x + i * xIncrement);
                int y = (int) (startPoint.y + i * yIncrement) == 0? startPoint.y : (int) (startPoint.y + i * yIncrement);
                paintGraphics.fillOval(x, y, width, height);
            }
        }
        else
        {
            int halfSize = width / 2; // Adjust based on brush size
            for (int i = 0; i <= steps; i++) {
                int x = (int) (startPoint.x + i * xIncrement) == 0? startPoint.x : (int) (startPoint.x + i * xIncrement);
                int y = (int) (startPoint.y + i * yIncrement) == 0? startPoint.y : (int) (startPoint.y + i * yIncrement);
    
                // Ensure x and y are within image bounds
                if (x >= 0 && x < image.get(currentLayer).getWidth() &&
                        y >= 0 && y < image.get(currentLayer).getHeight()) {
                    int distance = (int) Math.sqrt(Math.pow(x - endPoint.x, 2) + Math.pow(y - endPoint.y, 2));
                    if (distance <= halfSize) {
                        // Set pixel transparency (adjust alpha as needed)
                        image.get(currentLayer).setRGB(x, y, 0x00FFFFFF);
                    }
                }
            }
        }
        steps = 0;
        dx = 0;
        dy = 0;
        xIncrement = 0f;
        yIncrement = 0f;
        startPoint = e.getPoint();
        paintGraphics.dispose();
    }
    
    public static void addLayer(int layer)
    {
        ++currentLayer;
        image.add(currentLayer, new BufferedImage(width, height, BufferedImage.TYPE_INT_ARGB)); // the first image
        opacity.add(currentLayer, 1f);
        appear.add(currentLayer, true);
    }
    
    public static void setLayer(int layer)
    {
        currentLayer = layer;
    }
    
    public static void setOpaque(int layer, boolean bool)
    {
        appear.set(layer, bool);
    }
    
    public static void setOpacity(int layer, float transparency)
    {
        opacity.set(layer, transparency);
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

    }
}
