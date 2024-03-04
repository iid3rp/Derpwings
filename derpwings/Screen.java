package derpwings;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.*;

import java.util.*;

public class Screen extends JPanel
{
    public LayerManager layerManager;
    public Brush brush = new Brush();
    
    public Screen(int width, int height)
    {
        setLayout(null);
        setBounds(0, 0, width, height);
        setBackground(Color.GRAY);
        layerManager = new LayerManager(width, height);
        
        addMouseListener(new MouseAdapter()
        {
            @Override
            public void mouseClicked(MouseEvent e)
            {
                layerManager.flickDraw(e, layerManager.brush);String path = getClass().getResource("Brushes").getPath();
                repaint();
            }
            
            @Override
            public void mousePressed(MouseEvent e) 
            {
                layerManager.setStartPoint(e.getPoint());
                repaint();
            }
        
            @Override
            public void mouseReleased(MouseEvent e) 
            {
                layerManager.get(layerManager.currentLayer).stampBrush();
                repaint();
            }
        });


        addMouseMotionListener(new MouseMotionAdapter() 
        {
            @Override
            public void mouseDragged(MouseEvent e) 
            {
                layerManager.drawImage(e, layerManager.brush);
                repaint();
            }
        });
    }
    
    public void setBrushColor(Color c)
    {
        layerManager.setBrushColor(c);
    }
    
    @Override
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        g.drawImage(layerManager.getCanvas(), 0, 0, this);
    }
    
    public static void main(String[]  args)
    {
        // @iid3rp derpwings package reserved
    }
}