package derpwings;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.*;

import java.util.*;

public class Screen extends JPanel
{
    public BufferedImage canvasImage;
    
    public Screen(derpwings.Canvas canvas)
    {
        setLayout(null);
        setBounds(0, 0, 1280, 720); // resolution will be modified in the future...
        setBackground(Color.GRAY);
        canvasImage = new BufferedImage(canvas.getWidth(), canvas.getHeight(), BufferedImage.TYPE_INT_ARGB);
        addMouseListener(new MouseAdapter()
        {
            @Override
            public void mouseClicked(MouseEvent e)
            {
                Graphics2D paintGraphics = canvas.get(canvas.currentLayer).createGraphics();
                AlphaComposite alphaComposite = AlphaComposite.getInstance(AlphaComposite.SRC_OVER, (canvas.getColor().getAlpha() / 255f) / 10f); // ba
                paintGraphics.setComposite(alphaComposite);
                paintGraphics.setColor(canvas.getColor());
                paintGraphics.fillOval(e.getX(), e.getY(), canvas.getBrushWidth(), canvas.getBrushHeight());
                paintGraphics.dispose();
                iterateLayers(canvas);
            }
            
            @Override
            public void mousePressed(MouseEvent e) 
            {
                canvas.isDrawing = true;
                canvas.startPoint = e.getPoint();
                canvas.endPoint = e.getPoint();
            }
        
            @Override
            public void mouseReleased(MouseEvent e) 
            {
                canvas.isDrawing = false;
                canvas.startPoint = null;
                canvas.endPoint = null;
                iterateLayers(canvas);
            }
        });


        addMouseMotionListener(new MouseMotionAdapter() 
        {
            @Override
            public void mouseDragged(MouseEvent e) 
            {
                if (canvas.isDrawing) 
                {
                    canvas.paintProcess(10, 10, e);
                    iterateLayers(canvas);
                }
            }
        });
    }
    
    @Override
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        g.drawImage(canvasImage, 0, 0, this);
    }
    public void iterateLayers(ArrayList<BufferedImage> canvas)
    {
        for(BufferedImage bf : canvas)
        {
            Graphics2D g2d = canvasImage.createGraphics();
            g2d.drawImage(bf, 0, 0, null);
            g2d.dispose();
        }
        repaint();
    }
    
    public static void main(String[]  args)
    {
        // @iid3rp derpwings package reserved
    }
}