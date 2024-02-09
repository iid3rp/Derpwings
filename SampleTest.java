import derpwings.*;

import javax.swing.*;
import java.awt.event.*;
import java.awt.*;

public class SampleTest extends JFrame
{
	//@iid3rp reserved for derpwings java version here :3
    public SampleTest()
    {
        super();
        setSize(1280, 720);
        setBackground(Color.GRAY);
        setDefaultCloseOperation(3);
        setLocationRelativeTo(null);
        
        derpwings.Canvas canvas = new derpwings.Canvas(1280, 720);
        Screen screen = new Screen(canvas);
        add(screen);
        
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