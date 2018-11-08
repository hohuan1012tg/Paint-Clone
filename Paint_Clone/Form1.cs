﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingObjects;
using DrawingTools;

namespace Paint_Clone
{
    public partial class Form1 : Form
    {
        ObjectList objectList;
        IDrawingTool tool;
        Cursor usedCursor;

        public Form1()
        {
            InitializeComponent();

            // Setup form component
            selectRadio.Checked = true;

            objectList = new ObjectList(); 
            tool = new SelectTool(objectList);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            if (tool != null)
                tool.onPartialDraw(e.Graphics);

            objectList.drawAll(e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool != null)
                tool.onMouseDown(sender, e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tool != null)
                tool.onMouseMove(sender, e);
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            if (lineRadio.Checked)
            {
                tool = new LineTool(objectList);
                usedCursor = Cursors.Cross;
            }
            else if (rectRadio.Checked)
            {
                tool = new RectTool(objectList);
                usedCursor = Cursors.Cross;
            }
            else if (parallelogramRadio.Checked)
            {
                tool = new ParallelogramTool(objectList);
                usedCursor = Cursors.Cross;
            }
            else if (polygonRadio.Checked)
            {
                tool = new PolygonTool(objectList);
                usedCursor = Cursors.Cross;
            }
            else if (brokenLineRadio.Checked)
            {
                tool = new BrokenLineTool(objectList);
                usedCursor = Cursors.Cross;
            }
            else if (circleArcRadio.Checked)
            {
                tool = new CircleArcTool(objectList);
                usedCursor = Cursors.Cross;
            }
            else if (circleRadio.Checked)
            {
                tool = new CircleTool(objectList);
                usedCursor = Cursors.Cross;
            }
            else if (ellipseRadio.Checked)
            {
                tool = new EllipseTool(objectList);
                usedCursor = Cursors.Cross;
            }
            else if (ellipseArcRadio.Checked)
            {
                tool = new EllipseArcTool(objectList);
                usedCursor = Cursors.Cross;
            }
            else if (selectRadio.Checked)
            {
                tool = new SelectTool(objectList);
                usedCursor = Cursors.Arrow;
            }

            tool.setOwner(this);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (tool != null)
                tool.reset(sender);
            Cursor = Cursors.Arrow;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = usedCursor;
        }
    }
}
