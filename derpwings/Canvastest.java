package derpwings;

import java.awt.*;
import java.awt.event.*;
import java.awt.geom.*;
import java.awt.image.BufferedImage;
import javax.swing.*;

public class Canvastest extends JPanel 
{

    private boolean isDrawing = false;
    private BufferedImage canvasControl, paintControl, layerControl;
    private Graphics2D canvasGraphics, paintGraphics, layerGraphics; // Graphics2D object for the BufferedImage
    private Point startPoint, endPoint; // Store starting point of each drag
    private float opacity = .25f;
    

    public Canvastest() 
    {
        setLayout(null);
        setBounds(0, 0, 1280, 720);
        setBackground(Color.GRAY);

        canvasControl = new BufferedImage(1280, 720, BufferedImage.TYPE_INT_ARGB);
        paintControl = new BufferedImage(1280, 720, BufferedImage.TYPE_INT_ARGB);
        layerControl = new BufferedImage(1280, 720, BufferedImage.TYPE_INT_ARGB);
        canvasGraphics = canvasControl.createGraphics(); // the graphics for the panel
        paintGraphics = paintControl.createGraphics(); // paintbrush control
        layerGraphics = layerControl.createGraphics(); // the current layer of the painting

        addMouseListener(new MouseAdapter()
        {
            @Override
            public void mousePressed(MouseEvent e) 
            {
                isDrawing = true;
                startPoint = e.getPoint();
                endPoint = e.getPoint();
            }
        
            @Override
            public void mouseReleased(MouseEvent e) 
            {
                isDrawing = false;
                startPoint = null;
                endPoint = null;
            }
        });


        addMouseMotionListener(new MouseMotionAdapter() 
        {
             @Override
            public void mouseDragged(MouseEvent e) 
            {
                if (isDrawing) 
                {
                    endPoint = e.getPoint();

                    // Adjust alpha value within the valid range
                    paintGraphics.setColor(new Color(0, 0, 0, 0.3f));
            
                    // Draw a series of connected ovals to represent the line
                    int numberOfOvals = 10;  // Adjust the number of ovals as needed
                    for (int i = 0; i < numberOfOvals; i++) {
                        double t = (double) i / (numberOfOvals - 1);
                        int x = (int) (startPoint.x + t * (endPoint.x - startPoint.x));
                        int y = (int) (startPoint.y + t * (endPoint.y - startPoint.y));
                        paintGraphics.fillOval(x - 25, y - 25, 50, 50);  // Adjust oval dimensions
                    }
            
                    startPoint = endPoint;
            
                    // Corrected drawing order:
                    canvasGraphics.drawImage(paintControl, 0, 0, null);  // Draw paintControl directly to canvasControl
                    repaint();  // Update the panel                
                }        
            }
        });
    }
    
    public void canvasPaint()
    {
        canvasGraphics.drawImage(layerControl, 0, 0, null);
    }

    @Override
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        g.drawImage(canvasControl, 0, 0, this);
    }

    public static void main(String[] args) 
    {
        SwingUtilities.invokeLater(() -> {
            JFrame frame = new JFrame("Canvas Example");
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setLayout(null);

            Canvas canvas = new Canvas();
            canvas.setBounds(0, 0, 1280, 720);
            frame.add(canvas);

            frame.setSize(new Dimension(1280, 720));
            frame.setLocationRelativeTo(null);
            frame.setVisible(true);
        });
    }
}
