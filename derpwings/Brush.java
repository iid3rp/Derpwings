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
            // setting the brush size;
            this.setBrushSize(20);
            
            // setting the color of the brush;
            this.setColor(Color.WHITE);
            
            // creating a custom brush: it will be deprecated in the future..
            //createCustomBrush();
            
            // testing the color technique
            // Graphics2D g2d = brushImage.createGraphics();
//             g2d.setColor(Color.RED);
//             g2d.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_IN, 1f));
//             g2d.fillRect(0, 0, 1000, 1000);
//             g2d.dispose();
// 
//             String xd = getClass().getResource("Brushes").getPath();
//             String filename = "coloredAir.png"; 
//             File outputFile = new File(xd + File.separator + filename);
// 
//             try
//             {
//                 ImageIO.write(brushImage, "png", outputFile);
//                 System.out.println("Image saved to: " + outputFile.getAbsolutePath());
//             } 
//             catch (IOException e) 
//             {
//                 e.printStackTrace();
//             }
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }
    }
    
    public void createCustomBrush()
    {
        // default brush thingy:
        brushImage = new BufferedImage(1020, 1020, BufferedImage.TYPE_INT_ARGB);
        for(int i = 0; i <= 127; i++)
        {
            Graphics2D g2d = brushImage.createGraphics();
            g2d.setColor(new Color(0, 0, 200, 1));
            g2d.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_OVER, .5f));
            g2d.fillOval(i * 4, i * 4, 1020 - i * 8, 1020 - i * 8);
            g2d.dispose();
        }
        String path = getClass().getResource("Brushes").getPath();
        String filename = "GreenAir.png"; 
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
    
    public void setBrushSize(int size)
    {
        try
        {
            brushImage = new BufferedImage(size, size, BufferedImage.TYPE_INT_ARGB);
            String path = getClass().getResource("Brushes/GreenAir.png").getPath();
            Image image = ImageIO.read(new File(path));
            image = image.getScaledInstance(size, size, Image.SCALE_SMOOTH);
            Graphics2D g2d = brushImage.createGraphics();
            g2d.drawImage(image, 0, 0, null);
            g2d.dispose();
        }
        catch(IOException e)
        {
            e.printStackTrace();
        }
    }
    
    public void setColor(Color color)
    {
        Graphics2D g2d = brushImage.createGraphics();
        g2d.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_IN, 1f));
        g2d.setColor(color);
        g2d.fillRect(0, 0, brushImage.getWidth(), brushImage.getHeight());
        g2d.dispose();
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