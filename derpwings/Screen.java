package derpwings;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.awt.image.*;

public class Screen extends JPanel
{
    public BufferedImage canvasImage;
    
    public Screen(derpwings.Canvas e)
    {
        setLayout(null);
        setBounds(0, 0, 1280, 720); // resolution will be modified in the future...
        setBackground(Color.GRAY);
        
        // gets the canvas to be put in the screen
        
        addMouseListener(new MouseAdapter()
        {
            @Override
            public void mouseClicked(MouseEvent e)
            {
                Graphics2D paintGraphics = canvas.get(currentLayer).createGraphics();
                AlphaComposite alphaComposite = AlphaComposite.getInstance(AlphaComposite.SRC_OVER, (color.getAlpha() / 255f) / 10f); // ba
                paintGraphics.setComposite(alphaComposite);
                paintGraphics.setColor(color);
                paintGraphics.fillOval(e.getX(), e.getY(), width, height);
                paintGraphics.dispose();
                iterateLayers();
            }
            
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
                iterateLayers();
            }
        });


        addMouseMotionListener(new MouseMotionAdapter() 
        {
            @Override
            public void mouseDragged(MouseEvent e) 
            {
                if (isDrawing) 
                {
                    Graphics2D paintGraphics = canvas.get(currentLayer).createGraphics();
                    
                    endPoint = e.getPoint();
                    int dx = endPoint.x - startPoint.x;
                    int dy = endPoint.y - startPoint.y;
                    int steps = Math.max(Math.abs(dx), Math.abs(dy));
                    double xIncrement = (double) dx / steps;
                    double yIncrement = (double) dy / steps;
                    
                    AlphaComposite alphaComposite = AlphaComposite.getInstance(AlphaComposite.SRC_OVER, color.getAlpha() / 255f);
                    paintGraphics.setComposite(AlphaComposite.getInstance(AlphaComposite.SRC));
                    paintGraphics.setColor(color);
                    
                    
                    // brushing input fixed!!!
                    for (int i = 0; i <= steps; i++) {
                        int x = (int) (startPoint.x + i * xIncrement) == 0? startPoint.x : (int) (startPoint.x + i * xIncrement);
                        int y = (int) (startPoint.y + i * yIncrement) == 0? startPoint.y : (int) (startPoint.y + i * yIncrement);
                        paintGraphics.fillOval(x, y, width, height);
                    }
                    startPoint = e.getPoint();
                    paintGraphics.dispose();
                    iterateLayers();
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
    public void iterateLayers()
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