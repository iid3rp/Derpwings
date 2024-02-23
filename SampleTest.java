import derpwings.*;

import javax.swing.*;
import java.awt.event.*;
import java.awt.*;

public class SampleTest extends JFrame
{
	//@iid3rp reserved for derpwings java version here :3
    public static derpwings.Screen screen;
    public SampleTest()
    {
        super();
        setSize(1280, 720);
        setBackground(Color.GRAY);
        setDefaultCloseOperation(3);
        setLocationRelativeTo(null);
        screen = new derpwings.Screen(1280, 720); // initialization of the canvas based on the resolution of the parameter
        add(screen);
        
        addKeyListener(new KeyAdapter()
        {
            @Override
            public void keyPressed(KeyEvent e)
            {
                if(e.getKeyCode() == KeyEvent.VK_ENTER)
                {
                    derpwings.Canvas.color = JColorChooser.showDialog(null, "Select a Color!", Color.BLACK);
                }
                if(e.getKeyCode() == KeyEvent.VK_A)
                {
                    String str = JOptionPane.showInputDialog(null, "select current layer");
                    derpwings.Canvas.currentLayer = Integer.parseInt(str) - 1;
                }
                if(e.getKeyCode() == KeyEvent.VK_Z)
                {
                    derpwings.Canvas.addLayer(derpwings.Canvas.currentLayer);
                }
                if(e.getKeyCode() == KeyEvent.VK_1)
                {
                    derpwings.Canvas.isDrawing = true;
                }
                if(e.getKeyCode() == KeyEvent.VK_2)
                {
                    derpwings.Canvas.isDrawing = false;
                }
            }
        });
        
        setVisible(true); // this should come last :3
    }
    
    public static void main(String[] args)
    {
        SwingUtilities.invokeLater(() ->
        {
            new SampleTest();
        });
    }
}