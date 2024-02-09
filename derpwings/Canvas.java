package derpwings;

import java.awt.*;
import java.awt.event.*;
import java.awt.image.BufferedImage;
import javax.swing.*;

import java.util.*;

public class Canvas extends ArrayList<BufferedImage> 
{

    private boolean isDrawing = false;
    private static BufferedImage canvasControl, paintControl, layerControl;
    private Point startPoint, endPoint; // Store starting point of each drag
    private float opacity = .25f;
    private static Color color = Color.BLACK;
    private static int currentLayer = 0;
    private static ArrayList<BufferedImage> canvas = new ArrayList<>();
    private static JFrame frame;    
    private static int width = 10, // Adjust width as needed
                       height = 10; // Adjust height as needed

    public Canvas() 
    {
        super();
        canvas.add(new BufferedImage(1280, 720, BufferedImage.TYPE_INT_ARGB)); // the first image
    }

    public static void main(String[] args) 
    {
        SwingUtilities.invokeLater(() -> {
            frame = new JFrame("Canvas Example");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setLayout(null);

            Canvas ca = new Canvas();
            ca.setBounds(0, 0, 1280, 720);
            frame.add(ca);

            frame.setSize(new Dimension(1280, 720));
            frame.setLocationRelativeTo(null);
            frame.setVisible(true);
        });
    }
}
