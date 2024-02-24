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
    
    public Brush()
    {
        try
        {
            // default brush thingy:
<<<<<<< HEAD
            String path = getClass().getResource("Brushes/air.png").getPath();
            brushImage = ImageIO.read(new File(path));
            
            // testing the color technique
            Graphics2D g2d = brushImage.createGraphics();
            g2d.setColor(Color.RED);
            g2d.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_IN, 1f));
            g2d.fillRect(0, 0, 1000, 1000);
            g2d.dispose();
            
            String xd = getClass().getResource("Brushes").getPath();
        String filename = "coloredAir.png"; 
        File outputFile = new File(xd + File.separator + filename);
        
        try
        {
            ImageIO.write(brushImage, "png", outputFile);
            System.out.println("Image saved to: " + outputFile.getAbsolutePath());
        } 
        catch (IOException e) 
        {
            e.printStackTrace();
        }

            
            // createCustomBrush();
=======
            String path = getClass().getResource("Brushes/rect.png").getPath();
            brushImage = ImageIO.read(new File(path));
>>>>>>> 79e32fc36dfcac1b462c8a3ec33731f47645d7be
        }
        catch(IOException e)
        {
            e.printStackTrace();
        }
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