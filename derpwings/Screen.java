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
        setBounds(0, 0, canvas.getWidth(), canvas.getHeight()); // resolution will be modified in the future...
        setBackground(Color.GRAY);
        canvasImage = new BufferedImage(derpwings.Canvas.getWidth(), derpwings.Canvas.getHeight(), BufferedImage.TYPE_INT_ARGB);
        addMouseListener(new MouseAdapter()
        {
            @Override
            public void mouseClicked(MouseEvent e)
            {
                Graphics2D paintGraphics = derpwings.Canvas.image.get(derpwings.Canvas.currentLayer).createGraphics();
                AlphaComposite alphaComposite = AlphaComposite.getInstance(AlphaComposite.SRC_OVER, (derpwings.Canvas.color.getAlpha() / 255f) / 10f); // ba
                paintGraphics.setComposite(alphaComposite);
                paintGraphics.setColor(derpwings.Canvas.color);
                paintGraphics.fillOval(e.getX(), e.getY(), derpwings.Canvas.getBrushWidth(), derpwings.Canvas.getBrushHeight());
                paintGraphics.dispose();
                iterateLayers(derpwings.Canvas.image, derpwings.Canvas.appear, derpwings.Canvas.opacity);
            }
            
            @Override
            public void mousePressed(MouseEvent e) 
            {
                derpwings.Canvas.startPoint = e.getPoint();
                derpwings.Canvas.endPoint = e.getPoint();
            }
        
            @Override
            public void mouseReleased(MouseEvent e) 
            {
                derpwings.Canvas.startPoint = null;
                derpwings.Canvas.endPoint = null;
                iterateLayers(derpwings.Canvas.image, derpwings.Canvas.appear, derpwings.Canvas.opacity);
            }
        });


        addMouseMotionListener(new MouseMotionAdapter() 
        {
            @Override
            public void mouseDragged(MouseEvent e) 
            {
                derpwings.Canvas.paintProcess(10, 10, e);
                iterateLayers(derpwings.Canvas.image, derpwings.Canvas.appear, derpwings.Canvas.opacity);
            }
        });
    }
    
    @Override
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        g.drawImage(canvasImage, 0, 0, this);
    }
    public void iterateLayers(ArrayList<BufferedImage> image, ArrayList<Boolean> appear, ArrayList<Float> opacity)
    {
        int i = 0;
        for(BufferedImage bf : image)
        {
            if(appear.get(i++))
            {
                Graphics2D g2d = canvasImage.createGraphics();
                g2d.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC_OVER, 1f));
                g2d.drawImage(bf, 0, 0, null);
                g2d.dispose();
            }
        }
        repaint();
    }
    
    public static void main(String[]  args)
    {
        // @iid3rp derpwings package reserved
    }
}