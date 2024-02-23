package derpwings;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.*;

import java.util.*;

public class Screen extends JPanel
{
    public LayerManager canvas;
    
    public Screen(int width, int height)
    {
        setLayout(null);
        setBounds(0, 0, width, height); // resolution will be modified in the future...
        setBackground(Color.GRAY);
        canvas = new LayerManager(width, height);
        
        addMouseListener(new MouseAdapter()
        {
            @Override
            public void mouseClicked(MouseEvent e)
            {
                canvas.flickDraw(e, null);
            }
            
            @Override
            public void mousePressed(MouseEvent e) 
            {
                canvas.setStartPoint(e.getPoint());
            }
        
            @Override
            public void mouseReleased(MouseEvent e) 
            {
                
            }
        });


        addMouseMotionListener(new MouseMotionAdapter() 
        {
            @Override
            public void mouseDragged(MouseEvent e) 
            {
                canvas.drawImage(null, null);
                
            }
        });
    }
    
    @Override
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        g.drawImage(canvas.getCanvas(), 0, 0, this);
    }
    
    public static void main(String[]  args)
    {
        // @iid3rp derpwings package reserved
    }
}