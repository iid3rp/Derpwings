package derpwings;

import java.awt.*;
import java.awt.image.*;
import java.util.*;
import java.io.*;
import javax.imageio.*;
import java.net.*;

public class Brush
{
    public BufferedImage brushImage;
    public Image paintImage;
    
    public Brush() throws IOException
    {
        // default brush thingy:
        brushImage = ImageIO.read(new File("Brushes/rect.png"));
    }
    
    public void createCustomBrush()
    {
        // default brush thingy:
        brushImage = new BufferedImage(1000, 1000, BufferedImage.TYPE_INT_ARGB);
        for(int i = 0; i <= 250; i++)
        {
            Graphics2D g2d = brushImage.createGraphics();
            g2d.setColor(new Color(0, 0, 0, 1));
            g2d.fillOval(i * 2, i * 2, 1000 - i * 4, 1000 - i * 4);
            g2d.dispose();
        }
        String path = getClass().getResource("Brushes").getPath();
        String filename = "air.png"; 
        File outputFile = new File(path + File.separator + filename);
        
        try
        {
            ImageIO.write(brushImage, "png", outputFile);
            System.out.println("Image saved to: " + outputFile.getAbsolutePath());
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }

    }
    
    public BufferedImage getImage()
    {
        return brushImage;
    }
    
    public static void main(String args[]) throws IOException
    {
        new Brush();
    } 
}